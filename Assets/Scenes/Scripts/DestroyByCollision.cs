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
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == strTag)
        {
            if (shield != null && shield.invulnerable == true)
            {
                bDestroyOther = false; //Player soll nicht zerstört werden


            }

            if (life <= 0)
            {
                Destroy(this.gameObject);
            }

            life = life - 1;
        }

    }
}
