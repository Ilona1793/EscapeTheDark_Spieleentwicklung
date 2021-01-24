using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorTools : MonoBehaviour
{
   [MenuItem("Tools/Reset Player Pref")]

   public static void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("<b> **** Player Pref Deleted </b>");
    }
}
