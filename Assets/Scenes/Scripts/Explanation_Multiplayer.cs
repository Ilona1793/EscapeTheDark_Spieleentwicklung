using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explanation_Multiplayer : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ShowMultiplayer()
    {
        SceneManager.LoadScene("Level1_Multiplayer");
    }
}
