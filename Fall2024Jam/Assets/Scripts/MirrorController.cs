using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MirrorController : MonoBehaviour
{
    [SerializeField] GameObject fullMirror;
    [SerializeField] GameObject slightlyCrackedMirror;
    [SerializeField] GameObject veryCrackedMirror;
    [SerializeField] GameObject brokenMirror;
    [SerializeField] private AudioClip glassHit;
    public List<GameObject> listOfEnemies = new List<GameObject>();

    private int bulletHitNum;

    private void Start()
    {
        bulletHitNum = -1;
        slightlyCrackedMirror.SetActive(false);
        veryCrackedMirror.SetActive(false);
        brokenMirror.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (listOfEnemies.Count > 0)
        {
            listOfEnemies = listOfEnemies.Where(item => item != null).ToList();
        }
        else if(bulletHitNum == -1)
        {
            ++bulletHitNum;
        }

        switch (bulletHitNum)
        {
            case 0:
                fullMirror.SetActive(false);
                slightlyCrackedMirror.SetActive(true);
                break;
            case 1:
                slightlyCrackedMirror.SetActive(false);
                veryCrackedMirror.SetActive(true);
                break;
            case >= 2:
                slightlyCrackedMirror.SetActive(false);
                veryCrackedMirror.SetActive(false);
                brokenMirror.SetActive(true);
                gameObject.GetComponent<Collider2D>().isTrigger = true;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collider.gameObject);
            if(listOfEnemies.Count == 0)
            {
                ++bulletHitNum;
                SoundFXManager.instance.PlaySFX(glassHit, transform, 1f);
            }
        }
    }
}
