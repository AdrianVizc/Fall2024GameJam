using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistBullet : MonoBehaviour
{
    [SerializeField] private float force = 20;
    private GameObject player;
    private Rigidbody2D rb;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        HitWall(collider);
        HitPlayer(collider);        
    }

    private void HitWall(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    private void HitPlayer(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("HIT PLAYER");
            Destroy(gameObject);
            playerController.TakeDamage(1);
        }
    }
}
