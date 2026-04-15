using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBarSlider;

    public PlayerHealth playerHealth;
    
    void Start()
    {
        playerHealth.currentHealth = playerHealth.maxHealth;
    }

    
    void Update()
    {
        healthBarSlider.maxValue = playerHealth.maxHealth;
        healthBarSlider.value = playerHealth.currentHealth;
        
    }
}
