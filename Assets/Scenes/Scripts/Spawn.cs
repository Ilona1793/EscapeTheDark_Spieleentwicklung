using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //max amount
    public int spawnAmount = 3;
    //amount of objects still to spawn
    private int spawnAmountDelta = 3;

    [SerializeField]
    GameObject goCreate;

    [SerializeField]
    float fTimeIntervals;

    [SerializeField]
    Vector3 v3SpawnPosJitter;
    

    float fTimer = 0;
    ShowUI _plattform; //neu
    FinalEnemy _finalEnemy;

    public List<GameObject> currentlySpawned;

    void Start()
    {
        spawnAmountDelta = spawnAmount;
        fTimer = fTimeIntervals;
        _plattform = FindObjectOfType<ShowUI>();//neu
        _finalEnemy = FindObjectOfType<FinalEnemy>();
    }

    void Update()
    {
        //neu
        if (_plattform.playerOnPlattform)
        {
            if(spawnAmountDelta > 0)
            {
                fTimer -= Time.deltaTime;
                if (fTimer <= 0)
                {
                    fTimer = fTimeIntervals;

                    spawnAmountDelta--;
                    var go = Instantiate(goCreate, transform.position, Quaternion.identity);
                    currentlySpawned.Add(go);
                }
            }
            
        }else
        {
            if (!_plattform.isTimerZero())
            {
                fTimer = fTimeIntervals;
                spawnAmountDelta = spawnAmount;
                foreach (GameObject go in currentlySpawned)
                {
                    
                    if (go != null)
                    {
                        Destroy(go);
                    }
                    currentlySpawned.Remove(go);
                }
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
