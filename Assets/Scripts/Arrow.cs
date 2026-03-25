using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Invoke(nameof(DestroyAfter), 3f);
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