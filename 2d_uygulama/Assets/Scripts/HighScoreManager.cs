using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    private string connectionString;
    private List<HighScore> listScores = new List<HighScore>();
    public GameObject scorePrefab;
    public Transform scoreParent;
    void Start()
    {
        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";
        CreateTable();
        ShowScores();
    }

    public void CreateTable()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string insertQuery = String.Format("CREATE TABLE if not exists HighScores(ScoreId INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE, Nick TEXT NOT NULL, Score INTEGER NOT NULL, Date DATETIME NOT NULL DEFAULT CURRENT_DATE)");
                dbCommand.CommandText = insertQuery;
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }

    }
    private void GetScores()
    {
        listScores.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string alltableQuery = "select distinct nick,score,date from HighScores order by Score desc limit 8";
                dbCommand.CommandText = alltableQuery;
                using (IDataReader dbReader = dbCommand.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        listScores.Add(new HighScore(dbReader.GetString(0),dbReader.GetInt32(1),dbReader.GetDateTime(2)));

                    }
                    dbConnection.Close();
                    dbReader.Close();
                }
            }
        }
    }
    public void InsertScores(string name, int newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string insertQuery = String.Format("insert into HighScores(Nick,Score) values(\"{0}\",\"{1}\")", name, newScore);
                dbCommand.CommandText = insertQuery;
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }
    private void ShowScores()
    {
        GetScores();
        for (int i = 0; i < listScores.Count; i++)
        {
            GameObject tempObject = Instantiate(scorePrefab);
            HighScore tempScore = listScores[i];
            tempObject.GetComponent<HighScoreScript>().SetScore(tempScore.Score.ToString(),tempScore.Nick,(i+1).ToString());

            tempObject.transform.SetParent(scoreParent);
            tempObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
    }
}
