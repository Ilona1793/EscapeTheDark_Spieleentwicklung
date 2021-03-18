using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalEnemy : MonoBehaviour
{
    public Text textFinalEnemy;

    public bool playerOnEndPlatform;

    public GameObject enemy;

    public GameObject textWin;

    private DestroyByCollisionEndEnemy enemyScript;

    private bool isShowingDefeatText = false;

    private Vector3 enemyStartPosition;

    private bool isShowingGreatText = false;

    public Slider sliderEnemies;

    void Start()
    {
        textFinalEnemy.gameObject.SetActive(false);
        playerOnEndPlatform = false;
        textFinalEnemy.gameObject.SetActive(false);
        enemyStartPosition = enemy.transform.position;
        enemyScript = enemy.GetComponent<DestroyByCollisionEndEnemy>();
        sliderEnemies.maxValue = enemyScript.life;
    }

    private void Update()
    {
        if (isShowingDefeatText)
        {
            StartCoroutine(showDefeatText());
        }
        if (isShowingGreatText)
        {
            StartCoroutine(showGreatText());
        }
        sliderEnemies.value = enemyScript.life;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            enemy.gameObject.SetActive(true);
            playerOnEndPlatform = true;
            isShowingDefeatText = true;
            sliderEnemies.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnEndPlatform = true;
            resetEnemy();
            sliderEnemies.gameObject.SetActive(false);
        }
    }

    private void resetEnemy()
    {
        enemy.transform.position = enemyStartPosition;
        if(enemyScript != null)
        {
            enemyScript.life = 9;
        }
        enemy.gameObject.SetActive(false);
    }

    public void enemyDefeated()
    {
        isShowingGreatText = true;
        sliderEnemies.gameObject.SetActive(false);
    }

    IEnumerator showDefeatText()
    {
        textFinalEnemy.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        textFinalEnemy.gameObject.SetActive(false);
        isShowingDefeatText = false;
    }

    IEnumerator showGreatText()
    {
        textWin.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        textWin.gameObject.SetActive(false);
        isShowingGreatText = false;

    }

}
