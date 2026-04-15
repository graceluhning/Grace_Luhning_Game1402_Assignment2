using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody _rb;
    public EnemyHealth enemyHealth;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Invoke(nameof(DestroyAfter), 3f);
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
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(5);
                DestroyAfter();
                Debug.Log("Enemy Took Damage!");
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