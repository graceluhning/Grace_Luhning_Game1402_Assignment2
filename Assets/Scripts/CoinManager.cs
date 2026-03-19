using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int Coins;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        Debug.Log("Created CoinManager");
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        UpdateCoinUI();
    }


    public void AddCoins(int amount)
    {
        Coins += amount;
        UpdateCoinUI();
        
    }

    public void RemoveCoins(int amount)
    {
        Coins -= amount;
        if (Coins < 0) Coins = 0;
        UpdateCoinUI();

    }
    
    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "COINS: " + Coins;
        }
    }
}