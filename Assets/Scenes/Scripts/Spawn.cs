using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject goCreate;

    [SerializeField]
    float fTimeIntervals;

    [SerializeField]
    Vector3 v3SpawnPosJitter;
    

    float fTimer = 0;
    ShowUI _plattform; //neu
    FinalEnemy _finalEnemy;


    // Start is called before the first frame update
    void Start()
    {
        fTimer = fTimeIntervals;
        _plattform = FindObjectOfType<ShowUI>();//neu
        _finalEnemy = FindObjectOfType<FinalEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        //neu
        if (_plattform.playerOnPlattform)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                fTimer = fTimeIntervals;
                Vector3 v3SpawnPos = transform.position;
                

                Instantiate(goCreate, transform.position, Quaternion.identity);
            }
        }

       /* if (_finalEnemy.playerOnEndPlatform)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                fTimer = fTimeIntervals;
                Vector3 v3SpawnPos = transform.position;


                Instantiate(goCreate, transform.position, Quaternion.identity);
            }
        }*/


    }
}
