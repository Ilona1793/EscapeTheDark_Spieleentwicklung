using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadLevelOnCollisionGeneral : MonoBehaviour
{

    [SerializeField]
    string strSceneName;

    public Text endText;
    public Text highscoreText;

    public string HighScoreLevelMinutes;
    public string HighScoreLevelSeconds;
    public string HighScoreLevelMilliseconds;

    GameController gameC;
    string timePlayingStr;

    AddPlayerControlledVelocity movement;

    private void Start()
    {
        gameC = FindObjectOfType<GameController>();

        movement = FindObjectOfType<AddPlayerControlledVelocity>();

        String minutes = PlayerPrefs.GetInt(HighScoreLevelMinutes, 100).ToString();
        String seconds = PlayerPrefs.GetInt(HighScoreLevelSeconds, 100).ToString();
        String milliseconds = PlayerPrefs.GetInt(HighScoreLevelMilliseconds, 100).ToString();

        highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Goal")
        {
            FindObjectOfType<AudioManager>().Play("Goal");
            gameC.gamePlaying = false;

            movement.stopGame = true;

            timePlayingStr = gameC.timePlaying.ToString("mm':'ss'.'ff");
            endText.gameObject.SetActive(true);

            int minutes = gameC.timePlaying.Minutes;
            int seconds = gameC.timePlaying.Seconds;
            int milliseconds = gameC.timePlaying.Milliseconds;


            //Überprüfen auf Minuten und Sekunden, sind Sekunden und Minuten gleich wird auf Millisekunden überprüft
            if (minutes <= PlayerPrefs.GetInt(HighScoreLevelMinutes, 100))
            {
            

                //Wenn die Minutenanzahl geringer ist als letztes Mal kann sofort Highscore angezeigt werden
                if (minutes < PlayerPrefs.GetInt(HighScoreLevelMinutes, 100))
                {
                    PlayerPrefs.SetInt(HighScoreLevelMinutes, minutes);
                    PlayerPrefs.SetInt(HighScoreLevelSeconds, seconds);
                    PlayerPrefs.SetInt(HighScoreLevelMilliseconds, milliseconds);
                    endText.text = "New Highscore-Time: " + timePlayingStr;
                    highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;
                }

                //ansonsten Überprüfung auf Sekunden
                else
                {
                    if (seconds <= PlayerPrefs.GetInt(HighScoreLevelSeconds, 100))
                    {

                        //Wenn Minuten und Sekundenanzahl gleich, überprüfe auf Millisekunden
                        if (minutes == PlayerPrefs.GetInt(HighScoreLevelMinutes, 100) && seconds == PlayerPrefs.GetInt(HighScoreLevelSeconds, 100))
                        {
                            if (milliseconds < PlayerPrefs.GetInt(HighScoreLevelMilliseconds, 100))
                            {
                                PlayerPrefs.SetInt(HighScoreLevelMinutes, minutes);
                                PlayerPrefs.SetInt(HighScoreLevelSeconds, seconds);
                                PlayerPrefs.SetInt(HighScoreLevelMilliseconds, milliseconds);
                                endText.text = "New Highscore-Time: " + timePlayingStr;
                                highscoreText.text = "Highscore: " + minutes + ":" + seconds + "." + milliseconds;
                            }

                        }
                        else
                        {
                            PlayerPrefs.SetInt(HighScoreLevelMinutes, minutes);
                            PlayerPrefs.SetInt(HighScoreLevelSeconds, seconds);
                            PlayerPrefs.SetInt(HighScoreLevelMilliseconds, milliseconds);
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
