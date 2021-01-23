using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{

    public GameObject uiObject;
    public GameObject timerEnemies;
    public bool playerOnPlattform;

    public int countdownTimeEnemies;
    public TextMesh countdownTextEnemies;

    void Start()
    {
        uiObject.SetActive(false);
        timerEnemies.SetActive(false);
        playerOnPlattform =  false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            playerOnPlattform = true;
            uiObject.SetActive(true);
            timerEnemies.SetActive(true);
            StartCoroutine("WaitForSec");
            StartCoroutine(CountdownEnemies());
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        
    }

    IEnumerator CountdownEnemies()
    {
        while (countdownTimeEnemies > 0)
        {
            countdownTextEnemies.text = countdownTimeEnemies.ToString();

            yield return new WaitForSeconds(1f);

            countdownTimeEnemies--;
        }

        countdownTextEnemies.text = "GOOD JOB!";

        yield return new WaitForSeconds(1f);
        Destroy(timerEnemies);
    }
}
