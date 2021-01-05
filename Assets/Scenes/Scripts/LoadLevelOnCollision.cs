using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadLeve1OnCollision : MonoBehaviour
{
    [SerializeField]
    string strTag;

    [SerializeField]
    string strSceneName;

    public Text endText;
    public Text highscoreText;

    GameController gameC;
    string timePlayingStr;

    public bool stopLevel;


    private void Start()
    {
        gameC = FindObjectOfType<GameController>();
        //addPCV = FindObjectOfType<AddPlayerControlledVelocity>();

        stopLevel = false;
        //PlayerPrefs.DeleteAll();

        String minutes = PlayerPrefs.GetInt("HighScore Minutes", 100).ToString();
        String seconds = PlayerPrefs.GetInt("HighScore Seconds", 100).ToString();
        String milliseconds = PlayerPrefs.GetInt("HighScore Milliseconds", 100).ToString();


        highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == strTag)
        {
            //Debug.Log(addPCV.startGame);
            //addPCV.endGame = true;
            stopLevel = true;
            gameC.gamePlaying = false;

            timePlayingStr = gameC.timePlaying.ToString("mm':'ss'.'ff");
            endText.gameObject.SetActive(true);
            //endText.text = "Score-Time: " + timePlayingStr;

            int minutes = gameC.timePlaying.Minutes;
            int seconds = gameC.timePlaying.Seconds;
            int milliseconds = gameC.timePlaying.Milliseconds;

            //PlayerPrefs.SetString("HighScore", "Highscore: " + timePlayingStr);
            //endText.text = "Your Time: " + timePlayingStr;

            //Überprüfen auf Minuten und Sekunden, sind Sekunden und Minuten gleich wird auf Millisekunden überprüft
            if (minutes <= PlayerPrefs.GetInt("HighScore Minutes", 100))
            {
                Debug.Log("Minutes:");
                Debug.Log(minutes);
                Debug.Log(PlayerPrefs.GetInt("HighScore Minutes", 100));
                Debug.Log("Seconds:");
                Debug.Log(seconds);
                Debug.Log(PlayerPrefs.GetInt("HighScore Seconds", 100));

                if (seconds <= PlayerPrefs.GetInt("HighScore Seconds", 100))
                {

                    //Wenn Minuten und Sekundenanzahl gleich, überprüfe auf Millisekunden
                    if (minutes == PlayerPrefs.GetInt("HighScore Minutes", 100) && seconds == PlayerPrefs.GetInt("HighScore Seconds", 100))
                    {
                        if (milliseconds < PlayerPrefs.GetInt("HighScore Milliseconds", 100))
                        {
                            PlayerPrefs.SetInt("HighScore Minutes", minutes);
                            PlayerPrefs.SetInt("HighScore Seconds", seconds);
                            PlayerPrefs.SetInt("HighScore Milliseconds", milliseconds);
                            endText.text = "New Highscore-Time: " + timePlayingStr;
                            highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;
                        }

                    }
                    else
                    {
                        PlayerPrefs.SetInt("HighScore Minutes", minutes);
                        PlayerPrefs.SetInt("HighScore Seconds", seconds);
                        PlayerPrefs.SetInt("HighScore Milliseconds", milliseconds);
                        endText.text = "New Highscore-Time: " + timePlayingStr;
                        highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;
                    }
                }


            }


            StartCoroutine(showHighscoreText());
        }

    }


    IEnumerator showHighscoreText()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(strSceneName);
        endText.gameObject.SetActive(false);
    }



    public void ResetHighscore()
    {
        PlayerPrefs.DeleteAll();
        highscoreText.text = "Highscore: - ";
    }
}
