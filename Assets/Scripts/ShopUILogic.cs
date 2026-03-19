using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUILogic : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private PlayerController playerController;
    
    [SerializeField] GameObject marketUI;
    [SerializeField] Market market;

    [SerializeField] private Button armorButton;
    [SerializeField] TMP_Text armorText;
    public bool armorBought;
    
    [SerializeField] private Button spellButton;
    [SerializeField] TMP_Text spellText;
    public bool spellBought;
    
    [SerializeField] private Button axeButton;
    [SerializeField] TMP_Text axeText;
    public bool axeBought;
    
    public void exitShop()
    {
        marketUI.SetActive(false);
        market._marketOpen = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        Debug.Log("Exit Shop");
    }

    public void buyArmor()
    {
        if (armorBought) return;

        if (coinManager.Coins >= 10)
        {
            coinManager.RemoveCoins(10);
            armorBought = true;
            playerController.BuyArmor();

            armorText.text = "BOUGHT";
            armorButton.interactable = false;
            
            Debug.Log("Bought Armor!");
        }
        
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    public void buySpell()
    {
        if (spellBought) return;

        if (coinManager.Coins >= 10)
        {
            coinManager.RemoveCoins(10);
            spellBought = true;

            spellText.text = "BOUGHT";
            spellButton.interactable = false;

            Debug.Log("Bought Spell!");
        }
        
        else
        {
            Debug.Log("Not enough coins!");
        }

    }

    public void buyAxe()
    {
        if (axeBought) return;

        if (coinManager.Coins >= 10)
        {
            coinManager.RemoveCoins(10);
            axeBought = true;

            axeText.text = "BOUGHT";
            axeButton.interactable = false;

            Debug.Log("Bought Axe!");
        }
        
        else
        {
            Debug.Log("Not enough coins!");
        }

    }
    
    
}
