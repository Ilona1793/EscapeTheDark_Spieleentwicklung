using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalEnemy : MonoBehaviour
{
    public Text textFinalEnemy;

    public bool playerOnEndPlatform;

    public GameObject enemy;

    void Start()
    {
        textFinalEnemy.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            enemy.gameObject.SetActive(true);
            playerOnEndPlatform = true;
            StartCoroutine(showDefeatText());
        }
    }

    IEnumerator showDefeatText()
    {
        textFinalEnemy.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        textFinalEnemy.gameObject.SetActive(false);
    }
    
}
