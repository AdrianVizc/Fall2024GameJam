using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomEntered : MonoBehaviour
{
    [SerializeField] GameObject boss;

    void Start()
    {
        boss.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            boss.SetActive(true);
        }
    }
}
