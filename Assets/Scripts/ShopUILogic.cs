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

    public AudioClip chestSound;
    public AudioClip nopeSound;
    
    void Awake() // on awake
    {
        armorBought = false;
        axeBought = false;
        spellBought = false;
    }
    
    public void exitShop() 
    {
        marketUI.SetActive(false);
        market._marketOpen = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        Debug.Log("Exit Shop");
    }

    public void buyArmor() // armor purchase logic
    {
        if (armorBought) return;

        if (coinManager.Coins >= 10) // if the player has enough coins
        {
            coinManager.RemoveCoins(10);
            armorBought = true; // set bool to true
            playerController.moveSpeed = 12; // upgrade movespeed

            armorText.text = "BOUGHT"; // change UI 
            armorButton.interactable = false;
            
            Debug.Log("Bought Armor!");
            
            AudioSource.PlayClipAtPoint(chestSound, Camera.main.transform.position); // play audio clip
        }
        
        else
        {
            Debug.Log("Not enough coins!");
            AudioSource.PlayClipAtPoint(nopeSound, Camera.main.transform.position); // play audio clip
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
            AudioSource.PlayClipAtPoint(chestSound, Camera.main.transform.position);
        }
        
        else
        {
            Debug.Log("Not enough coins!");
            AudioSource.PlayClipAtPoint(nopeSound, Camera.main.transform.position);
        }

    }

    public void buyAxe()
    {
        if (axeBought) return;

        if (coinManager.Coins >= 30)
        {
            coinManager.RemoveCoins(30);
            axeBought = true;

            coinManager.coinsPer += 2; // add additional coin to coinsPer function in CoinManager

            axeText.text = "BOUGHT";
            axeButton.interactable = false;

            Debug.Log("Bought Axe!");
            AudioSource.PlayClipAtPoint(chestSound, Camera.main.transform.position);
        }
        
        else
        {
            Debug.Log("Not enough coins!");
            AudioSource.PlayClipAtPoint(nopeSound, Camera.main.transform.position);
        }

    }
    
}
