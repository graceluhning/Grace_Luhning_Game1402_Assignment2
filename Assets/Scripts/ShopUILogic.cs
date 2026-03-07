using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUILogic : MonoBehaviour
{
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
        
        Debug.Log("Exited Shop");
    }

    public void buyArmor()
    {
        if (armorBought) return;
        
        armorBought = true;

        armorText.text = "BOUGHT";
        armorButton.interactable = false;
        
        Debug.Log("Bought Armor!");
    }

    public void buySpell()
    {
        if (spellBought) return;
        
        spellBought = true;

        spellText.text = "BOUGHT";
        spellButton.interactable = false;
        
        Debug.Log("Bought Spell!");
      
    }

    public void buyAxe()
    {
        if (axeBought) return;
        
        axeBought = true;

        axeText.text = "BOUGHT";
        axeButton.interactable = false;
        
        Debug.Log("Bought Axe!");
       
    }
    
    
}
