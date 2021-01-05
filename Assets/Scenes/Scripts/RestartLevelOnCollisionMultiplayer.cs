using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelOnCollisionMultiplayer : MonoBehaviour
{

    [SerializeField] 
    public Transform Player;
    [SerializeField]
    public Transform Player2;
    [SerializeField]
    public Transform RespawnPoint;

    //add:
    [SerializeField]
    public Transform RespawnPoint2;



    private void OnCollisionEnter(Collision collision)
    {
      if(collision.collider.tag == "Player") {
            FindObjectOfType<AudioManager>().Play("Fall");
            Player.transform.position = RespawnPoint.transform.position;
        }



        if (collision.collider.tag == "Player2") {
            FindObjectOfType<AudioManager>().Play("Fall");

            //add:
            Player2.transform.position = RespawnPoint2.transform.position;
        }


    }

  
}
