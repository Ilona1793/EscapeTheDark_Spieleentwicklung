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

    public float pushForce = 25f;

    public float invincibilityTime = 0.5f;
    private float invincibilityTimeDelta = 0f;
    private bool isInvincible = false;

    private SphereCollider sCollider;

    public FinalEnemy finalEnemyScript;

    private void Start()
    {
        sCollider = GetComponent<SphereCollider>();
        if(finalEnemyScript == null)
        {
            finalEnemyScript = FindObjectOfType<FinalEnemy>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isInvincible)
        {
            if (collision.collider.tag == strTag)
            {
                Vector3 direction = transform.position - collision.transform.position;

                GetComponent<Rigidbody>().AddForce(direction.normalized * pushForce, ForceMode.Impulse);

                sCollider.enabled = false;
                isInvincible = true;

                if (shield != null && shield.invulnerable == true)
                {
                    bDestroyOther = false; //Player soll nicht zerstört werden
                }

                if (life <= 0)
                {
                    wall.gameObject.SetActive(false);
                    finalEnemyScript.enemyDefeated();
                    Destroy(this.gameObject);
                }

                life = life - 1;
                
            }
        }
            

    }

    public void Update()
    {
        if (invincibilityTimeDelta > invincibilityTime && isInvincible)
        {
            isInvincible = false;
            invincibilityTimeDelta = 0f;
            sCollider.enabled = true;
        }
        else if (isInvincible)
        {
            invincibilityTimeDelta += Time.deltaTime;
        }
    }

}


