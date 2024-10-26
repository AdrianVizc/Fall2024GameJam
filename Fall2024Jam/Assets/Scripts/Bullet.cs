using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    private float time = 0f;

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
    }
}
