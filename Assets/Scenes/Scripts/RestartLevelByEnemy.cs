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

    public SafePoint[] _safePoint;
    //Shield shield;
    public Shield[] _shield;


    private void Start()
    {
        collected = false;
   
    }



    private void OnCollisionEnter(Collision collision)
    {
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
                    this.gameObject.transform.position = RespawnPoints[_safePoint[i].safePointNumber].transform.position;
                }
            }



            //Wenn keine Fahne eingesammelt wird
            if (collected == false)
            {
                /* for (number = 0; number < _shield.Length; i++)
                  {
                      //und kein Schild aktiv oder vorhanden ist: NEUSTART
                      if (_shield[number].invulnerable == false | _shield[number] == null) { }
                      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                  }
                 */

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }



}
