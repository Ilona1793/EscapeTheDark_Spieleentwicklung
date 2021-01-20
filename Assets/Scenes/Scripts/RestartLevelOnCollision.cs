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



    SafePoint _safePoint;

    private void Start()
    {
        _safePoint = FindObjectOfType<SafePoint>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == strTag)
        {
            FindObjectOfType<AudioManager>().Play("Fall");
            if (_safePoint != null && _safePoint.respawnPlayer)
            {
                Player.transform.position = RespawnPoints[_safePoint.safePointNumber].transform.position;
            }
            else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
