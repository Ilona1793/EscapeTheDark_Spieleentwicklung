﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerControlledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 v3Force;

    [SerializeField]
    KeyCode keyPostitiv;

    [SerializeField]
    KeyCode keyNegative;

    
    public bool startGame;

    //add:
    public bool stopGame;




    void Start()
    {
        startGame = false;

        //add:
        stopGame = false;

        StartCoroutine(CountdownToStart());
    }

    void FixedUpdate()
    {
        if (startGame)
        {
            if (Input.GetKey(keyPostitiv))
                GetComponent<Rigidbody>().velocity += v3Force;

            if (Input.GetKey(keyNegative))
                GetComponent<Rigidbody>().velocity -= v3Force;

        }

        //add:
        if (stopGame) 
        {
            v3Force = Vector3.zero;
            GetComponent<Rigidbody>().velocity = v3Force;
        }


    }

    IEnumerator CountdownToStart()
    {
      yield return new WaitForSeconds(3f);
      startGame = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            FindObjectOfType<AudioManager>().Play("Arrow");

            if (Input.GetKey(keyPostitiv))
            {
                v3Force.z = v3Force.z + 0.5f;
                StartCoroutine(BoostTime());
            }
                
            
        }
    }

    IEnumerator BoostTime()
    {
        yield return new WaitForSeconds(1f);
        v3Force.z= v3Force.z -0.5f;
    }

}
