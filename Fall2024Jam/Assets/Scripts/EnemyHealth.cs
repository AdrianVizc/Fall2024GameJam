using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Health = 5;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip impactSFX;

    private void Update()
    {
        Dead();
    }

    private void Dead()
    {
        if (Health == 0)
        {
            SoundFXManager.instance.PlaySFX(deathSFX, transform, 1f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "PlayerBullet")
        {
            Health -= 1;
            SoundFXManager.instance.PlaySFX(impactSFX, transform, 1f);
            //Debug.Log("Hit Enemy");
        }
        /*else
        {
            Debug.Log("Seomthing Else");
        }*/
    }
}
