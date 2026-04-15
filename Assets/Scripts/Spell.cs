using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody _rb;
    public EnemyHealth enemyHealth;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Invoke(nameof(DestroyAfter), 5f);
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
                enemyHealth.TakeDamage(7);
                DestroyAfter();
                Debug.Log("Enemy Took Damage!");
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.rotation = Quaternion.LookRotation(_rb.linearVelocity);
    }

    void DestroyAfter()
    {
        Destroy(gameObject);
    }
}