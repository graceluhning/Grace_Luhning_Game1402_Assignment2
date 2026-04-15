using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Animator EnemyAnimator;
    
    [SerializeField] public int maxHealth;
    public int currentHealth;

    public CoinManager coinManager;
    
    
    void Awake()
    {
        if (coinManager == null)
        {
            GameObject ui = GameObject.FindWithTag("CoinManager");

            if (ui != null)
            {
                coinManager = ui.GetComponent<CoinManager>();
            }
            else
            {
                Debug.LogError("CoinManager null!");
            }
        }
        
        currentHealth = maxHealth;
        
        if (EnemyAnimator == null)
            EnemyAnimator = GetComponent<Animator>();
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        if(currentHealth <= 0)
        {
            EnemyAnimator.SetBool("Attack", false);
            EnemyAnimator.SetBool("Idle", false);
            EnemyAnimator.SetBool("Walk", false);
            EnemyAnimator.SetBool("Chase", false);
            EnemyAnimator.SetBool("Die", true);
            
            
            transform.DOScale(0, 1f).SetEase(Ease.InBack).OnComplete(() =>
            {
                Destroy(gameObject);
                coinManager.AddCoins();
                Debug.Log("Added Coins from Enemy Death");
            });
        }
        
    }
    
    
}
