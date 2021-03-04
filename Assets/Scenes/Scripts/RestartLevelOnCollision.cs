using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelOnCollision : MonoBehaviour
{
    [SerializeField]
    string strTag;

    //add:
    [SerializeField]
    public Transform Player;

    [SerializeField]
    public GameObject RespawnField;

    /* [SerializeField]
     public Transform RespawnPoint;*/

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

        // Debug.Log("distance 1 : " + Vector3.Distance(transform.position, RespawnPoints[0].position));
        // Debug.Log("distance 2 : " + Vector3.Distance(transform.position, RespawnPoints[1].position));

        //shield = FindObjectOfType<Shield>();

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == strTag)
        {
            FindObjectOfType<AudioManager>().Play("Fall");
            for (i = 0; i < _safePoint.Length; i++)
            {

                if (_safePoint[i] != null && _safePoint[i].respawnPlayer)
                {
                    collected = true;
                    Player.transform.position = RespawnPoints[_safePoint[i].safePointNumber].transform.position;
                }
            }


            if (collected == false)
            {
                /*   
                  if (_shield!= null && _shield.invulnerable == false)
                {
                    // Debug.Log("Shield Invulnerable : " + shield.invulnerable);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                
               

               
                for (number = 0; number < _shield.Length; i++)
                {
                    //Fall1: Schilder im Spiel aber keines aktiv-> Neustart
                    if (_shield[number] != null && _shield[number].invulnerable == false)
                    {
                        // Debug.Log("Shield Invulnerable : " + shield.invulnerable);
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }  */

                /*
                //Fall2: Keine Schilder da-> Neustart
                if (_shield == null)
                {
                    // Debug.Log("No Shield : " + shield.invulnerable);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                if (this.gameObject.tag == "RespawnField")
                {
                    Debug.Log("Normal");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }*/


                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }



    }
}

