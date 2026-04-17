using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private InputAction shootInput;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform aimTrack;
    [SerializeField] private ShopUILogic shopLogic;

    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _spell;
    [SerializeField] private float shootForce;

    private GameObject shootObject;
    private Vector3 _shootDirection;
    private PlayerState _currentState;
    private PlayerController _playerController;
    
    [SerializeField] private AudioClip shootSound;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        shootObject = _arrow; // default weapon
    }

    void Update()
    {
        // Equip arrow
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shootObject = _arrow;
            shootForce = 6;
            Debug.Log("Equipped Arrow");
        }

        // Equip spell
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (shopLogic.spellBought)
            {
                shootObject = _spell;
                shootForce = 30;
                Debug.Log("Equipped Spell");
            }
            else
            {
                Debug.Log("Spell Not Bought");
            }
        }
    }

    void OnEnable()
    {
        shootInput.Enable();
        shootInput.performed += Shoot;
        _playerController.OnStateUpdated += StateUpdate;
    }

    void OnDisable()
    {
        shootInput.performed -= Shoot;
        _playerController.OnStateUpdated -= StateUpdate;
    }

    private void StateUpdate(PlayerState state)
    {
        _currentState = state;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        if (_currentState != PlayerState.AIM) return;

        _shootDirection = (aimTrack.position - shootPoint.position).normalized;
            
        AudioSource.PlayClipAtPoint(shootSound, Vector3.zero);

        GameObject projectile = Instantiate(shootObject, shootPoint.position, Quaternion.LookRotation(_shootDirection)); // get shoot object at position

        if (projectile.TryGetComponent<Rigidbody>(out Rigidbody rb)) // apply physics
        {
            rb.AddForce(shootForce * _shootDirection, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Projectile prefab is missing a Rigidbody!");
        }
    }
}