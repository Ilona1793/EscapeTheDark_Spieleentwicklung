using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadLevel1OnCollision : MonoBehaviour
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

        String minutes = PlayerPrefs.GetInt("HighScore Minutes", 100).ToString();
        String seconds = PlayerPrefs.GetInt("HighScore Seconds", 100).ToString();
        String milliseconds = PlayerPrefs.GetInt("HighScore Milliseconds", 100).ToString();


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

          
            if (minutes <= PlayerPrefs.GetInt("HighScore Minutes", 100))
            {
                if (minutes < PlayerPrefs.GetInt("HighScore Minutes", 100))
                {
                    PlayerPrefs.SetInt("HighScore Minutes", minutes);
                    PlayerPrefs.SetInt("HighScore Seconds", seconds);
                    PlayerPrefs.SetInt("HighScore Milliseconds", milliseconds);
                    endText.text = "New Highscore-Time: " + timePlayingStr;
                    highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;
                }
                else
                {

                    if (seconds <= PlayerPrefs.GetInt("HighScore Seconds", 100))
                    {
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
