using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour
{

    public int blinkAmount = 10;

    [SerializeField]
    public float invulnerabilityTime;

    public bool invulnerable;
    Color standard;

    RestartLevelByEnemy enemyCollision;


    private void Start()
    {
        standard = this.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        enemyCollision = FindObjectOfType<RestartLevelByEnemy>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            FindObjectOfType<AudioManager>().Play("Shield");
            var shieldController = other.GetComponentInParent<ShieldController>();
            if (shieldController != null)
            {
                shieldController.deactiveShieldObject();
            }
            StartCoroutine(InvulnerabilityTime(invulnerabilityTime));
        }
    }


    IEnumerator InvulnerabilityTime(float time)
    {
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        invulnerable = true;


        yield return new WaitForSeconds(time -1);
        for(int i = 0; i < blinkAmount; i++)
        {
            if(i % 2 == 0)
            {
                ChangeColor(standard);
                yield return new WaitForSeconds(0.125f);
            }else
            {
                ChangeColor(Color.cyan);
                yield return new WaitForSeconds(0.125f);
            }
        }





        FindObjectOfType<AudioManager>().Play("Shield");
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", standard);
        invulnerable = false;
        //Für Collision ist Shield auch wieder deaktiviert
        enemyCollision.activeShield = false;


    }

    private void ChangeColor(Color col)
    {
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", col);
    }
}