using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject goCreate;

    [SerializeField]
    float fTimeIntervals;

    [SerializeField]
    Vector3 v3SpawnPosJitter;


    float fTimer = 0;
    FinalEnemy _finalEnemy;



    void Start()
    {
        fTimer = fTimeIntervals;
        _finalEnemy = FindObjectOfType<FinalEnemy>();
    }

    void Update()
    {


        if (_finalEnemy.playerOnEndPlatform)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                fTimer = fTimeIntervals;
                Vector3 v3SpawnPos = transform.position;


                Instantiate(goCreate, transform.position, Quaternion.identity);
            }
        }


    }
}

