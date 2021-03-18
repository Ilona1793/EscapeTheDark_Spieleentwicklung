using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalEnemy : MonoBehaviour
{
    public Text textFinalEnemy;

    public bool playerOnEndPlatform;

    public GameObject enemy;

    [SerializeField]
    float fTimer;


    public GameObject wall;


    void Start()
    {
        textFinalEnemy.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerOnEndPlatform)
        {
            fTimer -= Time.deltaTime;
            if (fTimer <= 0)
            {
                //enemy.gameObject.SetActive(false);
                textFinalEnemy.text = "Escape";
                wall.gameObject.SetActive(false);
            }
        }
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
