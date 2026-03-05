using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private InputAction shootInput;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject projectile;

    [SerializeField] private float shootForce;
    
    private GameObject _arrow;
    void OnEnable()
    {
        shootInput.Enable();
        shootInput.performed += Shoot;
    }

    void OnDisable()
    {
        shootInput.performed -= Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
       _arrow = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
       _arrow.GetComponent<Rigidbody>().AddForce(shootForce * shootPoint.forward);
    }
}
