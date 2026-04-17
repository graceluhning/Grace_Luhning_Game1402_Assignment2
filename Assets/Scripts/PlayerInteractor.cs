using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private InputAction interactionInput;

    private IInteractable _interactable;

    void OnEnable()
    {
        interactionInput.Enable();
        interactionInput.performed += Interact;
    }   

    void OnDisable()
    {
        interactionInput.performed -= Interact;
        interactionInput.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        _interactable = other.GetComponent<IInteractable>();

        if (_interactable == null) return;

        _interactable.OnHoverIn();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_interactable == null) return;

        _interactable.OnHoverOff();
        _interactable = null;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
        _interactable?.OnInteract();
    }
}