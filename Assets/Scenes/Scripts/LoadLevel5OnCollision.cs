using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadLevel5OnCollision : MonoBehaviour
{
    [SerializeField]
    string strTag;

    [SerializeField]
    string strSceneName;

    public Text endText;
    public Text highscoreText;

    GameController gameC;
    string timePlayingStr;

    //add:
    AddPlayerControlledVelocity movement;


    private void Start()
    {
        gameC = FindObjectOfType<GameController>();

        //add:
        movement = FindObjectOfType<AddPlayerControlledVelocity>();

        String minutes = PlayerPrefs.GetInt("HighScore5 Minutes", 100).ToString();
        String seconds = PlayerPrefs.GetInt("HighScore5 Seconds", 100).ToString();
        String milliseconds = PlayerPrefs.GetInt("HighScore5 Milliseconds", 100).ToString();


        highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == strTag)
        {
            FindObjectOfType<AudioManager>().Play("Goal");
            gameC.gamePlaying = false;

            //add:
            movement.stopGame = true;

            timePlayingStr = gameC.timePlaying.ToString("mm':'ss'.'ff");
            endText.gameObject.SetActive(true);

            int minutes = gameC.timePlaying.Minutes;
            int seconds = gameC.timePlaying.Seconds;
            int milliseconds = gameC.timePlaying.Milliseconds;

            //Überprüfen auf Minuten und Sekunden, sind Sekunden und Minuten gleich wird auf Millisekunden überprüft
            if (minutes <= PlayerPrefs.GetInt("HighScore5 Minutes", 100))
            {

                //Wenn die Minutenanzahl geringer ist als letztes Mal kann sofort Highscore angezeigt werden
                if (minutes < PlayerPrefs.GetInt("HighScore5 Minutes", 100))
                {
                    PlayerPrefs.SetInt("HighScore5 Minutes", minutes);
                    PlayerPrefs.SetInt("HighScore5 Seconds", seconds);
                    PlayerPrefs.SetInt("HighScore5 Milliseconds", milliseconds);
                    endText.text = "New Highscore-Time: " + timePlayingStr;
                    highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;
                }

                //ansonsten Überprüfung auf Sekunden
                else
                {

                    if (seconds <= PlayerPrefs.GetInt("HighScore5 Seconds", 100))
                    {

                        //Wenn Minuten und Sekundenanzahl gleich, überprüfe auf Millisekunden
                        if (minutes == PlayerPrefs.GetInt("HighScore5 Minutes", 100) && seconds == PlayerPrefs.GetInt("HighScore5 Seconds", 100))
                        {
                            if (milliseconds < PlayerPrefs.GetInt("HighScore5 Milliseconds", 100))
                            {
                                PlayerPrefs.SetInt("HighScore5 Minutes", minutes);
                                PlayerPrefs.SetInt("HighScore5 Seconds", seconds);
                                PlayerPrefs.SetInt("HighScore5 Milliseconds", milliseconds);
                                endText.text = "New Highscore-Time: " + timePlayingStr;
                                highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;
                            }

                        }
                        else
                        {
                            PlayerPrefs.SetInt("HighScore5 Minutes", minutes);
                            PlayerPrefs.SetInt("HighScore5 Seconds", seconds);
                            PlayerPrefs.SetInt("HighScore5 Milliseconds", milliseconds);
                            endText.text = "New Highscore-Time: " + timePlayingStr;
                            highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;
                        }
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
