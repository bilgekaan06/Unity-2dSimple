using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    HighScoreManager scoreManager;
    public GameObject outroImage;
    public static int goldCounter = 0;
    public GameObject goldCounterImage;
    public Text goldCounterText;
    void Start()
    {
        scoreManager = GetComponent<HighScoreManager>();
        outroImage = GameObject.Find("OutroImage");
        outroImage.SetActive(false);
    }
    void Update()
    {
        goldCounterText.text = goldCounter.ToString();
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(h * Time.deltaTime * 4, 0));//sağ ve sola kaymamız için
    }
    void OnCollisionEnter2D()
    {
        print("çarpışma oldu");
        outroImage.SetActive(true);
        CurrentAddScore();
    }

    void CurrentAddScore()
    {
        scoreManager.InsertScores(MainMenuScript.myNick, goldCounter);
        Invoke("Died", 1f);
    }
    void Died()
    {
        goldCounter = 0;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        MainMenuScript.myNick = string.Empty;
    }
}
