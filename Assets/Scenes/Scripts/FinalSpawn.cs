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


    // Start is called before the first frame update
    void Start()
    {
        fTimer = fTimeIntervals;
        _finalEnemy = FindObjectOfType<FinalEnemy>();
    }

    // Update is called once per frame
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

