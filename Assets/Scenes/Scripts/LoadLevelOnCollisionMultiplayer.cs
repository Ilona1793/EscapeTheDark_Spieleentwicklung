using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadLevelOnCollisionMultiplayer : MonoBehaviour
{
  [SerializeField]
  string strSceneName;

    private void OnCollisionEnter(Collision collision)
    {
        //Player Prefs speichern aktuellen Gewinner

        if (collision.collider.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Goal");
            PlayerPrefs.SetString("Winner","Player 1");
            SceneManager.LoadScene(strSceneName);
        }

        else if (collision.collider.tag == "Player2")
        {
            FindObjectOfType<AudioManager>().Play("Goal");
            PlayerPrefs.SetString("Winner", "Player 2");
            SceneManager.LoadScene(strSceneName);
        }
    }
}
