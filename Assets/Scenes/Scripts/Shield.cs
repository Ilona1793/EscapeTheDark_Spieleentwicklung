using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour
{

    [SerializeField]
    public float invulnerabilityTime;

    public bool invulnerable;
    Color standard;


    private void Start()
    {
        standard = this.gameObject.GetComponent<Renderer>().material.GetColor("_Color");

    }


    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Shield"))
            {
                FindObjectOfType<AudioManager>().Play("Clock");
                //other.GetComponent<Renderer>().enabled = false;
                Destroy(other.gameObject);


                StartCoroutine(InvulnerabilityTime(invulnerabilityTime));



            }
    }


    IEnumerator InvulnerabilityTime(float time)
    {
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        invulnerable = true;


        yield return new WaitForSeconds(time);

        FindObjectOfType<AudioManager>().Play("Clock");
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", standard);
        invulnerable = false;

    }
    /* [SerializeField]
     public Transform Player;

     [SerializeField]
     public float invulnerabilityTime;

     public bool invulnerable;
      Color standard;


     private void Start()
     {
         standard = Player.GetComponent<Renderer>().material.GetColor("_Color");

     }


     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Player"))
         {
             FindObjectOfType<AudioManager>().Play("Clock");
             this.gameObject.GetComponent<Renderer>().enabled = false;


             StartCoroutine(InvulnerabilityTime(invulnerabilityTime));


         }
     }


     IEnumerator InvulnerabilityTime(float time)
     {
         Player.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
         invulnerable = true;

         yield return new WaitForSeconds(time);

         FindObjectOfType<AudioManager>().Play("Clock");
         Player.GetComponent<Renderer>().material.SetColor("_Color", standard);
         invulnerable = false;

     }*/
}