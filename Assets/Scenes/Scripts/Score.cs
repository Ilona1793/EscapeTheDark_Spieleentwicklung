using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text level1;
    public Text level2;
    public Text level3;
    public Text level4;
    public Text level5;


    private void Start()
    {
        //Zeigt Highscores aller Level über PlayerPrefs der einzelnen LoadLevelOnCollision Skripte an

        String minutes1 = PlayerPrefs.GetInt("HighScore Minutes", 100).ToString();
        String seconds1 = PlayerPrefs.GetInt("HighScore Seconds", 100).ToString();
        String milliseconds1 = PlayerPrefs.GetInt("HighScore Milliseconds", 100).ToString();

        level1.text =  minutes1 + ":" + seconds1 + "." + milliseconds1;


        String minutes2 = PlayerPrefs.GetInt("HighScore2 Minutes", 100).ToString();
        String seconds2 = PlayerPrefs.GetInt("HighScore2 Seconds", 100).ToString();
        String milliseconds2 = PlayerPrefs.GetInt("HighScore2 Milliseconds", 100).ToString();

        level2.text =  minutes2 + ":" + seconds2 + "." + milliseconds2;


        String minutes3 = PlayerPrefs.GetInt("HighScore3 Minutes", 100).ToString();
        String seconds3 = PlayerPrefs.GetInt("HighScore3 Seconds", 100).ToString();
        String milliseconds3 = PlayerPrefs.GetInt("HighScore3 Milliseconds", 100).ToString();

        level3.text =  minutes3 + ":" + seconds3 + "." + milliseconds3;



        String minutes4 = PlayerPrefs.GetInt("HighScore4 Minutes", 100).ToString();
        String seconds4 = PlayerPrefs.GetInt("HighScore4 Seconds", 100).ToString();
        String milliseconds4 = PlayerPrefs.GetInt("HighScore4 Milliseconds", 100).ToString();

        level4.text =  minutes4 + ":" + seconds4 + "." + milliseconds4;


        String minutes5 = PlayerPrefs.GetInt("HighScore5 Minutes", 100).ToString();
        String seconds5 = PlayerPrefs.GetInt("HighScore5 Seconds", 100).ToString();
        String milliseconds5 = PlayerPrefs.GetInt("HighScore5 Milliseconds", 100).ToString();

        level5.text = minutes5 + ":" + seconds5 + "." + milliseconds5;
    }



    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
