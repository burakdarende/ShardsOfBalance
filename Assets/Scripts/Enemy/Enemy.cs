using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100;
    public float health = 100;
    public Animator animator;
    [SerializeField] FloatingHealthBar healthBar;
    private Rigidbody rb;
    private bool isDead;
    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        healthBar.UpdateHealthBar(health, enemyHealth);
        health = enemyHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, enemyHealth);
        if(health <= 0)
        {
            Die();   
        }
       
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true; 

        animator.SetTrigger("die");

        if(healthBar != null)
        {
            healthBar.HideHealthBar();
        }

        if (rb != null)
        {
            
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        Destroy(gameObject, 3f);
    }
}
