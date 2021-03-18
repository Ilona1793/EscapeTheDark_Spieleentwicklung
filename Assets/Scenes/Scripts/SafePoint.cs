using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePoint : MonoBehaviour
{
    [SerializeField]
    public int safePointNumber;

    public bool respawnPlayer;


    void Start()
    {
        respawnPlayer = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Flag");
            respawnPlayer = true;
            this.gameObject.SetActive(false);
            
        }
    }
}
