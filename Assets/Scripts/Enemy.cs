using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    GameObject target;
    public Transform player;
    public float moveSpeed;
    public Vector3 directionToTarget;

    public int maxHealth = 100;
    int currentHealth;

    public int damage;

    public GameObject deathEffect;
    public float deathEffectTimer;

    public GameObject experience;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 3f);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MoveMonster();
        RotateMonster(player.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }

    }

    void MoveMonster()
    {
        if(target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    
    void RotateMonster(Vector2 player)
    {
        var offset = 90f;
        Vector2 direction = player - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    

    void Die()
    {
        GameObject deatheffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deatheffect, deathEffectTimer);
        Destroy(gameObject);
        Instantiate(experience, transform.position, Quaternion.identity);
    }
}