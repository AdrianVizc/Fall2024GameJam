using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] public float bulletForce = 20f;
    [SerializeField] public float shootingCooldown = 1f;
    [SerializeField] private AudioClip spellSFX;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Camera cam;
    private float timer;

    Vector2 mousePos;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timer > shootingCooldown)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        SoundFXManager.instance.PlaySFX(spellSFX, transform, 1f);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 fireDirection = (mousePos - (Vector2)firePoint.position).normalized;
        rb.AddForce(fireDirection * bulletForce, ForceMode2D.Impulse);
    }
}
