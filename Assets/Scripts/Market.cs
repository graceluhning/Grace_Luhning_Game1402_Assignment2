using UnityEngine;
using DG.Tweening;


public class Market : MonoBehaviour, IInteractable
{
    private Tween _loopTween;
    private Vector3 _originalScale;

    public bool _marketOpen = false;

    [SerializeField] private GameObject marketUI;
    [SerializeField] private ShopNPC shopNPC; 

    void Awake()
    {
        _originalScale = transform.localScale; // set original scale
    }

    public void OnHoverIn()
    {
        Debug.Log("Interact in!");
        _loopTween = transform.DOScale(1.7f, 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);

        Toast.Instance.ShowToast("Press \"E\" To Interact!");
    }

    public void OnHoverOff()
    {
        Debug.Log("Interact out!");
        _loopTween?.Kill();
        transform.DOScale(_originalScale, 0.5f);

        Toast.Instance.HideToast();
    }

    public void OnInteract()
    {
        Debug.Log($"Interacted with {gameObject.name}");
        marketUI.SetActive(true);
        _marketOpen = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

  
        if (shopNPC != null)
        {
            shopNPC.OnInteract();
        }
    }
}