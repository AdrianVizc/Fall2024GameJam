using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int Health = 5;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip impactSFX;
    private Animator animator;
    private bool tookDamage;
    private float time;

    const float DAMAGE_ANIMATION = 0.5f;

    private void Start()
    {
        tookDamage = false;
        animator = gameObject.GetComponent<Animator>();
        time = 0.0f;
    }

    private void FixedUpdate()
    {
        Dead();
        if (tookDamage)
        {
            time += Time.deltaTime;
            if( time > DAMAGE_ANIMATION )
            {
                time = 0.0f;
                tookDamage = false;
                animator.SetBool("TookDamage", false);
            }
        }
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
            tookDamage = true;
            animator.SetBool("TookDamage", true);
            //Debug.Log("Hit Enemy");
        }
        /*else
        {
            Debug.Log("Seomthing Else");
        }*/
    }
}
