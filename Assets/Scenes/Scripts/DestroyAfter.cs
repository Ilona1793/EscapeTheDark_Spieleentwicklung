﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField]
    float fTimer;
    ShowUI _plattform;


    void Start()
    {
        _plattform = FindObjectOfType<ShowUI>();

    }

    void Update()
    {
        if (_plattform.playerOnPlattform)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}


