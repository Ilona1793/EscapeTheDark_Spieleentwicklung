using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{

    public GameObject uiObject;
    public bool playerOnPlattform;

    public Slider sliderEnemies;
    public float countdownTimeEnemies = 15f;
    public Text countdownTextEnemies;

    public bool surviveTestActive = false;

    void Start()
    {
        uiObject.SetActive(false);
        sliderEnemies.gameObject.SetActive(false);
        countdownTextEnemies.gameObject.SetActive(false);
        playerOnPlattform = false;
        sliderEnemies.maxValue = countdownTimeEnemies;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            playerOnPlattform = true;
            uiObject.SetActive(true);
            sliderEnemies.gameObject.SetActive(true);
            surviveTestActive = true;
            //StartCoroutine("WaitForSec");
            //StartCoroutine(CountdownEnemies());
        }
    }


    private void Update()
    {
        if (playerOnPlattform)
        {
            if (countdownTimeEnemies > 0)
            {
                countdownTimeEnemies -= Time.deltaTime;
                sliderEnemies.value = countdownTimeEnemies;
            }
        }
        else
        {
            countdownTimeEnemies = 15f;
            sliderEnemies.value = countdownTimeEnemies;
        }
        if (isTimerZero())
        {
            countdownTextEnemies.gameObject.SetActive(true);

            sliderEnemies.gameObject.SetActive(false);
            StartCoroutine(waitSecondsBeforeDisable(2f, countdownTextEnemies.gameObject, true));

        }
        if (surviveTestActive)
        {
            StartCoroutine(waitSecondsBeforeDisable(1f, uiObject, false));
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlattform = false;
            countdownTimeEnemies = 15;
            sliderEnemies.value = countdownTimeEnemies;
            uiObject.SetActive(false);
            sliderEnemies.gameObject.SetActive(false);
        }
    }
    IEnumerator waitSecondsBeforeDisable(float timeToWait, GameObject goDisable, bool destroyAfter)
    {
        yield return new WaitForSeconds(timeToWait);
        goDisable.SetActive(false);
        surviveTestActive = false;
        if (destroyAfter)
        {
            Destroy(this);
        }
    }
   //IEnumerator CountdownEnemies()
   // {
   //     while (countdownTimeEnemies > 0)
   //     {
   //         if (playerOnPlattform)
   //         {
   //             sliderEnemies.value = countdownTimeEnemies;

   //             yield return new WaitForSeconds(0.05f);

   //             countdownTimeEnemies -= Time.deltaTime;
   //         }

   //     }

   //     sliderEnemies.gameObject.SetActive(false);
   //     yield return new WaitForSeconds(0.5f);
   //     countdownTextEnemies.gameObject.SetActive(true);
   //     yield return new WaitForSeconds(2f);
   //     countdownTextEnemies.gameObject.SetActive(false);

   //     Destroy(this);
   // }

    public bool isTimerZero()
    {
        return countdownTimeEnemies <= 0;
    }
}
