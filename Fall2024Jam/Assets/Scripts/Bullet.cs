using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer;

    private void Update()
    {
        BulletTimer();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collider.tag == "Dummy")
        {
            Destroy(gameObject);
        }
        if (collider.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }

    private void BulletTimer()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }
}
