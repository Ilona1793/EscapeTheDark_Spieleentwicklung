using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    public Transform Player;

    public Texture SampleTexture;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Clock");
            Destroy(this.gameObject);
            Player.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        }
    }

}
