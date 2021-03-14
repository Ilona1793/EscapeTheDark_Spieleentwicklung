using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               
using UnityEngine.SceneManagement;  
using TMPro;
using System.Security.Cryptography;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    ClockItem _clock;
    public Text clockText;

    public Text  timeCounter, countdownText;
    public int countdownTime;


    public bool gamePlaying;

    private float startTime, elapsedTime;

    public TimeSpan timePlaying;

    AudioManager _audio;

    private void Awake()
    {
        instance = this;
        _clock = FindObjectOfType<ClockItem>();
        _audio = FindObjectOfType<AudioManager>();

    }

    private void Start()
    {
        timeCounter.text = "Time: 00:00.00";

        gamePlaying = false;
        StartCoroutine(CountdownToStart());
    }

   
    private void BeginGame()
    {
        
        gamePlaying = true;

        startTime = Time.time;
    }


    private void Update()
    {
      setTimer();
    
    }

  
    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            _audio.Play("Countdown");
            countdownText.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        BeginGame();

        _audio.Play("Countdown-Go");
        countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }


    public void setTimer(){
      if (gamePlaying)
      {

            if (_clock.timeBonus == true)
            {
               
                StartCoroutine(timeBonus());

            }
            else {
               
                elapsedTime = Time.time - startTime;

            }

           
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");

            timeCounter.text = timePlayingStr;
      }
    }

    IEnumerator timeBonus() {

        clockText.gameObject.SetActive(true);
        elapsedTime = Time.time - startTime - 3f;
        yield return new WaitForSeconds(3f);
        clockText.gameObject.SetActive(false);

    }

 

}
