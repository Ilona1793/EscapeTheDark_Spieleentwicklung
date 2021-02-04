using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{

    public GameObject uiObject;
    public bool playerOnPlattform;

    public Slider sliderEnemies;
    public int countdownTimeEnemies;
    public Text countdownTextEnemies;

    void Start()
    {
        uiObject.SetActive(false);
        sliderEnemies.gameObject.SetActive(false);
        countdownTextEnemies.gameObject.SetActive(false);
        playerOnPlattform =  false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            playerOnPlattform = true;
            uiObject.SetActive(true);
            sliderEnemies.gameObject.SetActive(true);
            StartCoroutine("WaitForSec");
            StartCoroutine("CountdownEnemies");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2f);
        Destroy(uiObject);
    }

    IEnumerator CountdownEnemies()
    {
        sliderEnemies.maxValue = countdownTimeEnemies;

        while (countdownTimeEnemies > 0)
        {
            sliderEnemies.value = countdownTimeEnemies;
           
            yield return new WaitForSeconds(0.05f);

            countdownTimeEnemies -=1;
        }

        sliderEnemies.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        countdownTextEnemies.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        countdownTextEnemies.gameObject.SetActive(false);
    }
}
