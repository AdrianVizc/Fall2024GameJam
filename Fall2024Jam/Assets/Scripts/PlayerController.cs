using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed;
    Vector2 movement;
    Vector2 mousePos;
    Vector2 moveDir;
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

        moveDir = new Vector2(movement.x, movement.y);
        moveDir.Normalize();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movSpeed * moveDir * Time.fixedDeltaTime);
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
            Time.timeScale = 0;
        }
        hp.UpdateHealth();
    }
}
