using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Invoke(nameof(DestroyAfter), 5f);
    }

 
    void FixedUpdate()
    {
        _rb.rotation = Quaternion.LookRotation(_rb.linearVelocity);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Balloon") || collision.gameObject.CompareTag("Ground"))
        {
            DestroyAfter();
        }
       
    }

    void DestroyAfter()
    {
        Destroy(gameObject);
    }
}