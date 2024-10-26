using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistShooting : MonoBehaviour
{
    [SerializeField] private float rateOfFire = 2;
    public GameObject bullet;    
    public Transform bulletPos;
        
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > rateOfFire)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
