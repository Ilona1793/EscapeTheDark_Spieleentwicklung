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

   /* [SerializeField]
    public Transform RespawnPoint;*/

    // mehrere SafePoints:
     [SerializeField]
     public Transform [] RespawnPoints;

    int i;
    bool collected;

    SafePoint[] _safePoint;
    Shield shield;

    private void Start()
    {
        // _safePoint = FindObjectOfType<SafePoint>();
        _safePoint = FindObjectsOfType<SafePoint>();
        collected = false;

        shield = FindObjectOfType<Shield>();

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == strTag)
        {
            FindObjectOfType<AudioManager>().Play("Fall");
            for (i = _safePoint.Length - 1; i >= 0; --i)
            {
     
                if (_safePoint[i] != null && _safePoint[i].respawnPlayer)
                {
                    collected = true;
                    Player.transform.position = RespawnPoints[_safePoint[i].safePointNumber].transform.position;
                }
            }
                
                if (collected == false && shield.invulnerable == false)
                {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                 /*else
                 {
                     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                 }*/
            
          
        }
    }
}
