using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int Coins;
    public TextMeshProUGUI coinText;

    public int coinsPer = 2;

    private void Awake()
    {
        Debug.Log("Created CoinManager");
        
        Instance = this;
        
    }
    private void Start() // set coin UI on start
    {
        UpdateCoinUI();
    }
    
    public void AddCoins(int amount)
    {
        Coins += amount;
        UpdateCoinUI(); // chest addcoins function
        
    }

    public void AddCoins()
    {
        Coins += coinsPer;
        UpdateCoinUI(); // balloons addcoins function
        
    }

    public void RemoveCoins(int amount) // remove coins when something is bought function
    {
        Coins -= amount;
        if (Coins < 0) Coins = 0;
        UpdateCoinUI();

    }
    
    private void UpdateCoinUI() // updates the coin UI
    {
        if (coinText != null)
        {
            coinText.text = "COINS: " + Coins;
        }
    }
    
}