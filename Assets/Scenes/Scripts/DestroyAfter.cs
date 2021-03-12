using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField]
    float fTimer;
    ShowUI _plattform;
    FinalEnemy _finalEnemy;

    // Start is called before the first frame update
    void Start()
    {
        _plattform = FindObjectOfType<ShowUI>();
        _finalEnemy = FindObjectOfType<FinalEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_plattform.playerOnPlattform | _finalEnemy.playerOnEndPlatform)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
}


/* if (_finalEnemy.playerOnEndPlatform)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }*/
