using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3;
    public int damageAmount = 10;

    private void Awake()
    {
        Destroy(gameObject,life);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Enemy scriptini al
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Hasar ver
                enemy.TakeDamage(damageAmount);
            }

            
        }
        else
        {
          
        }
    }
}
