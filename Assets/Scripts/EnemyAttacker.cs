using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Collider headCollider;
    [SerializeField] public PlayerHealth playerHealth;
    [SerializeField] public int damageAmount;
    private void OnTriggerEnter(Collider other)
    {
        if (!headCollider.enabled) return;

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
