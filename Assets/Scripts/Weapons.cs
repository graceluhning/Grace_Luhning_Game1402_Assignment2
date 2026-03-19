using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    public GameObject[] weapons;
    
    [SerializeField] ShopUILogic shopLogic;

    void Start()
    {
        SelectWeapon(0);
    }

    void SelectWeapon(int index)
    {
        weapons[0].SetActive(false);
        weapons[1].SetActive(false);
        
        weapons[index].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && shopLogic.spellBought)
        {
            SelectWeapon(1);
        }
    }
    


}
