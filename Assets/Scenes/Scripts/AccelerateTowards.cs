using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateTowards : MonoBehaviour
{

    [SerializeField]
    Transform transTowards;

    [SerializeField]
    float fSpeed;

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        if (transTowards == null)
        {
            transTowards = FindObjectOfType<AddPlayerControlledVelocity>().transform;
        }
    }


    void Update()
    {
        rigid.velocity += (transTowards.position - transform.position).normalized * fSpeed * Time.deltaTime;
    }
}