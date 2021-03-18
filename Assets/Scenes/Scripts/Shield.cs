using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour
{

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
                Destroy(other.gameObject);
                StartCoroutine(InvulnerabilityTime(invulnerabilityTime));
            }
    }


    IEnumerator InvulnerabilityTime(float time)
    {
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        invulnerable = true;


        yield return new WaitForSeconds(time);

        FindObjectOfType<AudioManager>().Play("Shield");
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", standard);
        invulnerable = false;
        //Für Collision ist Shield auch wieder deaktiviert
        enemyCollision.activeShield = false;


    }
}