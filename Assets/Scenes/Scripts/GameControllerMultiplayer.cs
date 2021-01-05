using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               
using UnityEngine.SceneManagement;  
using TMPro;
using System.Security.Cryptography;

public class GameControllerMultiplayer : MonoBehaviour
{

    public Text  countdownText;
    public int countdownTime;


    // Start wird vor erstem Frame-Update aufgerufen
    private void Start()
    {
        //Countdown 3-2-1
        StartCoroutine(CountdownToStart());
    }

    //Countdown 3-2-1
    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            FindObjectOfType<AudioManager>().Play("Countdown");
            countdownText.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        FindObjectOfType<AudioManager>().Play("Countdown-Go");
        countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }


   

 

}
