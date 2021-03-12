using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartLevelByEnemy : MonoBehaviour
{
    // mehrere SafePoints:
    [SerializeField]
    public Transform[] RespawnPoints;

    int i;
    int number;
    bool collected;
    public bool activeShield;

    public SafePoint[] _safePoint;
    public Shield[] _shield;


    private void Start()
    {
        collected = false;
        activeShield = false;
       _shield = FindObjectsOfType<Shield>();
    }


    private void OnCollisionEnter(Collision collision)
    {

        //Sobald ein Schild eingesammelt wird, ist Variable activeShield true
        for (number = 0; number < _shield.Length; number++)
        {
            if (_shield[number].invulnerable == true)
            {
                activeShield = true;
            }
        }

        //Bei Kollision wird geprüft, ob Fahne gesammelt wurde und Player dorthin zurückgesetzt, wenn kein Schild eingesammelt wurde
        if (collision.collider.tag == "Enemy")
        {
            FindObjectOfType<AudioManager>().Play("Fall");

            for (i = 0; i < _safePoint.Length; i++)
            {

                if (_safePoint[i] != null && _safePoint[i].respawnPlayer)
                {
                    collected = true;

                    if (activeShield == false)
                    {
                        this.gameObject.transform.position = RespawnPoints[_safePoint[i].safePointNumber].transform.position;
                    }
                }
            }

            //Wenn keine Fahne und kein Schild eingesammelt wird, wird der Player an den Anfang zurückgestzt
            if (collected == false)
            {
                if (activeShield == false)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
             
            }
        }

    }
}




 /* 
 Debug.Log("Shield:" + shield.invulnerable);

                    if (shield.invulnerable == false)
                    {
                        this.gameObject.transform.position = RespawnPoints[_safePoint[i].safePointNumber].transform.position;
                    }
  *
  * 
  * 
  * for (number = 0; number < _shield.Length; i++)
                  {
                      //und kein Schild aktiv oder vorhanden ist: NEUSTART
                      if (_shield[number].invulnerable == false | _shield[number] == null) { }
                      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                  }
                 
 *
 * 
 * Wenn kein Schild vorhanden oder aktiv ist wird Player an letztes Fähnchen zurückgesetzt
                 for (number = 0; number < _shield.Length; number++)
                 {
                     Debug.Log("Number:" + number);
                     Debug.Log("InvulnurableShield:" + _shield[number].invulnerable);
                     if (_shield[number].invulnerable == true)
                     {
                         Debug.Log("Invulnerable:" + number);
                         activeShield = true;
                     }
                 }
                 if (activeShield == false) {
                     this.gameObject.transform.position = RespawnPoints[_safePoint[i].safePointNumber].transform.position;
                 }*/

