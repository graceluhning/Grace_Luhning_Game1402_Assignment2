using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUILogic : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private PlayerController playerController;
    
    [SerializeField] GameObject marketUI;
    [SerializeField] private Market market;

    [SerializeField] private Button armorButton;
    [SerializeField] TMP_Text armorText;
    public bool armorBought;
    
    [SerializeField] private Button spellButton;
    [SerializeField] TMP_Text spellText;
    public bool spellBought;
    
    [SerializeField] private Button axeButton;
    [SerializeField] TMP_Text axeText;
    public bool axeBought;

    [SerializeField] private AudioClip nopeSound;
    [SerializeField] private AudioClip boughtSound;
    
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
            AudioSource.PlayClipAtPoint(boughtSound, Vector3.zero);
        }
        
        else
        {
            Debug.Log("Not enough coins!");
            AudioSource.PlayClipAtPoint(nopeSound, Vector3.zero);
        }
    }

    public void buySpell()
    {
        if (spellBought) return;

        if (coinManager.Coins >= 20)
        {
            coinManager.RemoveCoins(20);
            spellBought = true;

            spellText.text = "BOUGHT";
            spellButton.interactable = false;

            Debug.Log("Bought Spell!");
            AudioSource.PlayClipAtPoint(boughtSound, Vector3.zero);
        }
        
        else
        {
            
            Debug.Log("Not enough coins!");
            AudioSource.PlayClipAtPoint(nopeSound, Vector3.zero);
        }

    }

    public void buyAxe()
    {
        if (axeBought) return;

        if (coinManager.Coins >= 30)
        {
            coinManager.RemoveCoins(30);
            axeBought = true;

            axeText.text = "BOUGHT";
            axeButton.interactable = false;

            coinManager.coinsPer += 2;

            Debug.Log("Bought Axe!");
            AudioSource.PlayClipAtPoint(boughtSound, Vector3.zero);
        }
        
        else
        {
            Debug.Log("Not enough coins!");
            AudioSource.PlayClipAtPoint(nopeSound, Vector3.zero);
        }

    }
    
    
}
