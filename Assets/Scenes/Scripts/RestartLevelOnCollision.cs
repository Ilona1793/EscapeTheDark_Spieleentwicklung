using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelOnCollision : MonoBehaviour
{
    [SerializeField]
    string strTag;

    [SerializeField]
    public Transform Player;

    [SerializeField]
    public Transform[] RespawnPoints;

    int i;
    bool collected;

    public SafePoint[] _safePoint;

    private void Start()
    {
        collected = false;
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }



    }
}

