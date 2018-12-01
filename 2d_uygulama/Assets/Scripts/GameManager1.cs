using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public Transform active;
    public Transform passive;
    private Transform randomSet;
    private float characterSpeed = 2f;
    public GameObject oyunaBasla;
    void Start()
    {
        StartCoroutine(CheckForVisiblity());
        StartCoroutine(Move());
    }

    void Update()
    {
    }
    IEnumerator CheckForVisiblity()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (active.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().isVisible == false)
            {
                Environment();
            }
        }

    }
    void Environment()
    {
        randomSet = passive.GetChild(Random.Range(0, passive.childCount));
        randomSet.parent = active;
        randomSet.SetAsLastSibling();
        randomSet.localPosition = active.GetChild(active.childCount - 2).localPosition + new Vector3(0, 8, 0);//-1 kendisi -2 sonuncusu
        
        randomSet = active.GetChild(0);
        randomSet.parent = passive;
        randomSet.localPosition = passive.GetChild(0).localPosition;

    }
    IEnumerator Move()
    {
        while (true)
        {
            characterSpeed = (Time.deltaTime) / 5 + characterSpeed;
            Camera.main.transform.Translate(Vector2.up * characterSpeed * Time.deltaTime);
            yield return null;
        }
    }
    public void OyunaBasla()
    {
        new WaitForSeconds(1);
        SceneManager.LoadScene("1", LoadSceneMode.Single);
    }
    public void HighScoreScene()
    {
        new WaitForSeconds(1);
        SceneManager.LoadScene("HighScore", LoadSceneMode.Single);
    }
}
