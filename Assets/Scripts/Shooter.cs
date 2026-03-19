using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private InputAction shootInput;

    
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform aimTrack;
    [SerializeField] public GameObject shootObject;
    
    [SerializeField] private float shootForce;

    [SerializeField] private ShopUILogic shopLogic;

    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _spell;
    
    private Vector3 _shootDirection;
    private PlayerState _currentState;
    private PlayerController _playerController;

    void Start()
    {
        shootObject = _arrow;
    }
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shootObject = _arrow;
            shootForce = 20;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && shopLogic.spellBought)
        {
            shootObject = _spell;
            shootForce = 30;
        }
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

    private void Shoot(InputAction.CallbackContext context)
    {
    
        if(_currentState != PlayerState.AIM) return;


        if (shootObject == _spell && !shopLogic.spellBought) return;
 
        _shootDirection = aimTrack.position - shootPoint.position;
        _shootDirection.Normalize();

    
        shootObject = Instantiate(shootObject, shootPoint.position, Quaternion.LookRotation(_shootDirection));

     
        shootObject.GetComponent<Rigidbody>().AddForce(shootForce * _shootDirection, ForceMode.Impulse);
    }
}

