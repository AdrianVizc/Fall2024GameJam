using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] public float bulletForce = 20f;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Camera cam;

    Vector2 mousePos;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 fireDirection = (mousePos - (Vector2)firePoint.position).normalized;
        rb.AddForce(fireDirection * bulletForce, ForceMode2D.Impulse);
    }
}
