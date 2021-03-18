using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByCollisionEndEnemy : MonoBehaviour
{
    [SerializeField]
    string strTag;

    [SerializeField]
    bool bDestroySelf = false;

    [SerializeField]
    bool bDestroyOther = false;

    public int life;

    Shield shield;

    public GameObject wall;

    public Text textWin;

   

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
                wall.gameObject.SetActive(false);
               // StartCoroutine(showGreatText());
                
            }

            life = life - 1;
        }

    }

    IEnumerator showGreatText()
    {
        textWin.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        textWin.gameObject.SetActive(false);

    }
}


