using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour
{
    [SerializeField] GameObject fullMirror;
    [SerializeField] GameObject slightlyCrackedMirror;
    [SerializeField] GameObject veryCrackedMirror;
    [SerializeField] GameObject brokenMirror;
    public List<GameObject> listOfEnemies = new List<GameObject>();

    private void Start()
    {
        slightlyCrackedMirror.SetActive(false);
        veryCrackedMirror.SetActive(false);
        brokenMirror.SetActive(false);
    }

    private void Update()
    {
        CheckRoomForEnemies();
        allEnemiesDead();

    }

    private void CheckRoomForEnemies()
    {
        for (int i = 0; i < listOfEnemies.Count; i++)
        {
            if (listOfEnemies[i] == null)
            {
                listOfEnemies.RemoveAt(i);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        hideSlightlyCrackedMirror(collider);
        hideVeryCrackedMirror(collider);
        Debug.Log("<3 Dom");
    }
    
    private void allEnemiesDead()
    {
        if (listOfEnemies.Count == 0)
        {
           fullMirror.SetActive(false);
           slightlyCrackedMirror.SetActive(true);
           //Glass Crack Audio
        }
    }

    private void hideSlightlyCrackedMirror(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PlayerBullet"))
        {
            slightlyCrackedMirror.SetActive(false);
            veryCrackedMirror.SetActive(true);
            //Glass Crack Audio
        }
    }
    private void hideVeryCrackedMirror(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PlayerBullet"))
        {
            veryCrackedMirror.SetActive(false);
            brokenMirror.SetActive(true);
            //Glass Shatter Audio
        }
    }
}
