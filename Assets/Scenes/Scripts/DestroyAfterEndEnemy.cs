using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterEndEnemy : MonoBehaviour
{
    [SerializeField]
    float fTimer;
    FinalEnemy _finalEnemy;

    void Start()
    {
        _finalEnemy = FindObjectOfType<FinalEnemy>();
    }

    void Update()
    {
        if (_finalEnemy.playerOnEndPlatform)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                Destroy(this.gameObject);
            }

        }
    }
}


