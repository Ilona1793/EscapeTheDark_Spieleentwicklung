using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame ()
  {
  
      SceneManager.LoadScene("Level1");
  }

  public void QuitGame ()
  {
    Debug.Log("Quit");
    Application.Quit();
  }

    public void ShowScore()
    {
        SceneManager.LoadScene("Score");
    }
    public void ShowLevelmanager()
    {
        SceneManager.LoadScene("Levelmanager");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ShowMultiplayer()
    {
        PlayerPrefs.DeleteKey("BuildIndex");
        PlayerPrefs.DeleteKey("Points Player1");
        PlayerPrefs.DeleteKey("Points Player2");
        SceneManager.LoadScene("Explanation Multiplayer");
    }
}
