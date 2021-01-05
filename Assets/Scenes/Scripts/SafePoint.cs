using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePoint : MonoBehaviour
{

    public bool respawnHexagon;

    void Start()
    {
        respawnHexagon = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            respawnHexagon = true;
        }
    }
}
