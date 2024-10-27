using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer: MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerController.TakeDamage(1);
        }
    }
}
