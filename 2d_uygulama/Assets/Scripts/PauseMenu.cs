using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public static bool isPaused = false;
    public GameObject pauseMenu_UI;
    public GameObject quitGame_UI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {

                resume();
            }
            else
            {

                pause();

            }
        }
    }
    public void resume()
    {
        pauseMenu_UI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }
    void pause()
    {
        pauseMenu_UI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void quitGame()
    {
        pauseMenu_UI.SetActive(false);
        quitGame_UI.SetActive(true);
        new WaitForSeconds(2);
        kapa();

    }
    public void backToMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
       //Player.gold_count = 0;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void kapa()
    {
        Application.Quit();
    }
}

