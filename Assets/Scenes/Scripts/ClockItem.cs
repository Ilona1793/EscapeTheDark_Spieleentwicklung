using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockItem : MonoBehaviour
{

  public  bool timeBonus = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Clock");
            Destroy(this.gameObject);
            timeBonus = true;
          }}


}
