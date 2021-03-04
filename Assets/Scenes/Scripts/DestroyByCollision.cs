using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByCollision : MonoBehaviour
{
    [SerializeField]
    string strTag;

    [SerializeField]
    bool bDestroySelf = false;

    [SerializeField]
    bool bDestroyOther = false;

    public int life;

    Shield shield;

    private void Start()
    {
        // _safePoint = FindObjectOfType<SafePoint>();
        shield = FindObjectOfType<Shield>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == strTag)
        {
            if (shield != null && shield.invulnerable == true)
            {
                //bDestroySelf = true;
                bDestroyOther = false;


            }

            if (life <= 0)
            {
                Destroy(this.gameObject);
            }

            if (bDestroyOther)
            { 
            Destroy(collision.gameObject);
            }

            life = life - 1;
            Debug.Log("LIFE:" + life);
           
        }

    }
}
