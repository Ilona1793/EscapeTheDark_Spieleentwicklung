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

        if (collision.collider.tag == "Enemy")
        {

            Debug.Log("Enemy-Collision");
            FindObjectOfType<AudioManager>().Play("Fall");

            for (i = 0; i < _safePoint.Length; i++)
            {

                if (_safePoint[i] != null && _safePoint[i].respawnPlayer)
                {
                    Debug.Log("SAFEPOINT");
                    Debug.Log(this.gameObject);
                    collected = true;

                    if (activeShield == false)
                    {
                        this.gameObject.transform.position = RespawnPoints[_safePoint[i].safePointNumber].transform.position;
                    }
                }
            }

            //Wenn keine Fahne eingesammelt wird
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

