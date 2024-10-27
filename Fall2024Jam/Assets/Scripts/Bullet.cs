using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        Delete();        
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
    }
    private void Delete()
    {
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }
}
