using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update () {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        if(GameIsPaused)
        {
          Resume();
        } else
        {
          Pause();
        }
      }
    }

    public void Resume()
    {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
    }

    void Pause()
    {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void LoadMenu()
    {
        //Für Multiplayer
        PlayerPrefs.DeleteKey("BuildIndex");
        PlayerPrefs.DeleteKey("Points Player1");
        PlayerPrefs.DeleteKey("Points Player2");

        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

       
    }

    public void QuitGame()
    {
        //Für Multiplayer
        PlayerPrefs.DeleteKey("BuildIndex");
        PlayerPrefs.DeleteKey("Points Player1");
        PlayerPrefs.DeleteKey("Points Player2");

        Debug.Log("Quit");
        Application.Quit();

        
    }


}
