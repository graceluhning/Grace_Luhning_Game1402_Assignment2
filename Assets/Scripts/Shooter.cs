using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private InputAction shootInput;


    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform aimTrack;
    [SerializeField] public GameObject shootObject;
    public GameObject projectile;

    [SerializeField] private float shootForce;

    [SerializeField] private ShopUILogic shopLogic;

    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _spell;

    private Vector3 _shootDirection;
    private PlayerState _currentState;
    private PlayerController _playerController;

    void Start()
    {
        shootObject = _arrow; // set shootobject to arrow on start
    }

    void Awake()
    {
        _playerController = GetComponent<PlayerController>(); //get player controller script
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipArrow();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && shopLogic.spellBought) // only allow spell equip if spell is bought
        {
           EquipSpell();
        }

        else
        {
            return;
        }
    }

    void EquipArrow() // arrow logic
    {
        Debug.Log("Equipped ");
        shootObject = _arrow; // make the shoot object the arrow
        shootForce = 6;
    }

    void EquipSpell() // spell logic
    {
        Debug.Log("Equipped Spell");
        shootObject = _spell; // make the shoot object the spell
        shootForce = 30;
    }


    void OnEnable()
    {
        shootInput.Enable();
        shootInput.performed += Shoot;

        _playerController.OnStateUpdated += StateUpdate;

    }

    void StateUpdate(PlayerState state)
    {
        _currentState = state;
    }

    void OnDisable()
    {
        shootInput.performed -= Shoot;
        _playerController.OnStateUpdated -= StateUpdate;

    }

    private void Shoot(InputAction.CallbackContext context) // shoot logic
    {
     
        if (_currentState != PlayerState.AIM) return; // if player not aiming, unable to shoot

        _shootDirection = aimTrack.position - shootPoint.position;
        _shootDirection.Normalize();

        Debug.Log("Shot");
        
        GameObject projectile = Instantiate(shootObject, shootPoint.position, Quaternion.LookRotation(_shootDirection)); // shoot math
        projectile.GetComponent<Rigidbody>().AddForce(shootForce * _shootDirection, ForceMode.Impulse);
    }

}

