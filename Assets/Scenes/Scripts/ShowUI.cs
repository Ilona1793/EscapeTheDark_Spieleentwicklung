using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public GameObject wall;

    public GameObject uiObject;
    public bool playerOnPlattform;

    public Slider sliderEnemies;
    public float countdownTimeEnemies = 15f;
    public Text countdownTextEnemies;

    public bool surviveTestActive = false;

    void Start()
    {
        uiObject.SetActive(false);
        wall.SetActive(false);
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
            wall.SetActive(true);
            sliderEnemies.gameObject.SetActive(true);
            surviveTestActive = true;

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
            wall.SetActive(false);
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

    public bool isTimerZero()
    {
        return countdownTimeEnemies <= 0;
    }
}
