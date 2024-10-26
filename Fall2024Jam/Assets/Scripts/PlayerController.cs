using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed;
    Vector2 movement;
    Vector2 mousePos;
    public Rigidbody2D rb;
    public Camera cam;

    [SerializeField]
    public int startHealth;

    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private Health hp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movSpeed * movement * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void SetStartingHealth(int health)
    {
        startHealth = health;
        currentHealth = health;
        hp.ShowHealth();
    }

    public int GetStartingHealth()
    {
        return startHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            //Game Over
        }
        hp.UpdateHealth();
    }
}
