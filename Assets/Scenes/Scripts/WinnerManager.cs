using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinnerManager : MonoBehaviour
{
    public Text winnerText;
    public Text scoreText;
    public Text finalWinnerText;

    int i = 1;
    int pointsP1 = 0;
    int pointsP2 = 0;
    String finalWinner;
   
    void Start()
    {
        String winner = PlayerPrefs.GetString("Winner", "It's a tie");
        winnerText.text = winner;

        finalWinnerText.text = "Go on!";

       
        if (PlayerPrefs.GetString("Winner", "") == "Player 1")
        {
            pointsP1 = PlayerPrefs.GetInt("Points Player1", 0) + 1;
            PlayerPrefs.SetInt("Points Player1", pointsP1);
            scoreText.text = PlayerPrefs.GetInt("Points Player1", 0) + ":" + PlayerPrefs.GetInt("Points Player2", 0);

        }
        if (PlayerPrefs.GetString("Winner", "") == "Player 2")
        {
            
            pointsP2 = PlayerPrefs.GetInt("Points Player2", 0) + 1;
            PlayerPrefs.SetInt("Points Player2", pointsP2);
            scoreText.text = PlayerPrefs.GetInt("Points Player1", 0) + ":" + PlayerPrefs.GetInt("Points Player2", 0);

        }

     
        if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            if (PlayerPrefs.GetInt("Points Player1", 0) > PlayerPrefs.GetInt("Points Player2", 0))
            {
                finalWinner = "Player 1";
            }
            if (PlayerPrefs.GetInt("Points Player2", 0) > PlayerPrefs.GetInt("Points Player1", 0))
            {
                finalWinner = "Player 2";
            }
            finalWinnerText.text = finalWinner + " wins the game";
        }
    }

    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + PlayerPrefs.GetInt("BuildIndex", 1));
        i = i+1;
        PlayerPrefs.SetInt("BuildIndex", i);

    }

    public void BackToMenu()
    {
   
        PlayerPrefs.DeleteKey("BuildIndex");
        PlayerPrefs.DeleteKey("Points Player1");
        PlayerPrefs.DeleteKey("Points Player2");
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        PlayerPrefs.DeleteKey("BuildIndex");
        PlayerPrefs.DeleteKey("Points Player1");
        PlayerPrefs.DeleteKey("Points Player2");
        SceneManager.LoadScene("Level1_Multiplayer");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        PlayerPrefs.DeleteKey("BuildIndex");
        PlayerPrefs.DeleteKey("Points Player1");
        PlayerPrefs.DeleteKey("Points Player2");
    }
}
