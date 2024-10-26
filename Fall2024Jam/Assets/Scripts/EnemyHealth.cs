using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Health = 5;

    private void Update()
    {
        Dead();
    }

    private void Dead()
    {
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "PlayerBullet")
        {
            Health -= 1;
            //Debug.Log("Hit Enemy");
        }
        /*else
        {
            Debug.Log("Seomthing Else");
        }*/
    }
}
