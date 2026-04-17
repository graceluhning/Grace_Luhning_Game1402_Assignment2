using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private Material normalMaterial;
    [SerializeField] private Material glowMaterial;
    
    [SerializeField] ShopUILogic shopLogic;
    [SerializeField] Collider capsuleCollider;
    [SerializeField] private Menus menus;

    [SerializeField] private GameObject sellerText;
    [SerializeField] private GameObject winText;

    private bool winUnlocked = false;
    


    void Start()
    {
        GetComponent<MeshRenderer>().material = normalMaterial; // start with material
    }

    private void openWin()
    {
        capsuleCollider.enabled = true; // enable collider on WinCon
        
        sellerText.SetActive(false);
        winText.SetActive(true); // change seller text at the shop
        
        GetComponent<MeshRenderer>().material = glowMaterial; // set glow material when all items purchased
    }

    void OnTriggerEnter(Collider other)
    {
        if (winUnlocked && other.CompareTag("Player"))
        {
            menus.gameWonUI.SetActive(true);
            menus.GameWon();
        }
    }

    void Update()
    {
        if (!winUnlocked && shopLogic.armorBought && shopLogic.axeBought &&
            shopLogic.spellBought) // if all items bought, open win
        {
            openWin();
            winUnlocked = true;
        }
    }

}
