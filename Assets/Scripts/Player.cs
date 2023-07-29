using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 mousePos;
    Vector2 movement;
    public Camera cam;

    public GameObject deathEffect;
    public float deathEffectTimer;

    public int maxHealth = 100;
    int currentHealth;

    public int maxExp = 0;
    int currentExp;

    public int level;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        currentExp = maxExp;
        level = 0;
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        LevelUpCheck();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }

    public void LevelUpCheck()
    {
        Debug.Log("level check");
        if(currentExp == 5)
        {
            level += 1;
            currentExp = 0;
        }
    }

    public void increaseExp()
    {
        currentExp += 1;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject playerEffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(playerEffect, deathEffectTimer);
        Destroy(this.gameObject);
    }
}
