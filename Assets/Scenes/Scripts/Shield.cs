using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour
{
    [SerializeField]
    public Transform Player;

    [SerializeField]
    public float invulnerabilityTime;

    public bool invulnerable;
     Color standard;

    [SerializeField]
    public int shieldNumber;

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

    }
}
