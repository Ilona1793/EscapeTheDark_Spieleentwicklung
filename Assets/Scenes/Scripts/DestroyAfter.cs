using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField]
    float fTimer;
    ShowUI _plattform;
    // Start is called before the first frame update
    void Start()
    {
        _plattform = FindObjectOfType<ShowUI>();
    }

    // Update is called once per frame
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
