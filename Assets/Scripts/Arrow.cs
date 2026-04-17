using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody _rb;
    public EnemyHealth enemyHealth;
    public int currentHealth;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Balloon") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balloon") || other.CompareTag("Ground"))
        {
            DestroyAfter();
        }
        
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(5);
                Debug.Log("Enemy Took Damage!");

                if (enemyHealth.currentHealth <= 0)
                {
                    DestroyAfter();
                }
                
            }
        }
    }
    
    void FixedUpdate()
    {
        _rb.rotation = Quaternion.LookRotation(_rb.linearVelocity);
    }

    void DestroyAfter()
    {
        Destroy(gameObject);
    }
}