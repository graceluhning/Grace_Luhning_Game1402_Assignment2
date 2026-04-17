using UnityEngine;
using DG.Tweening;
using TMPro;

public class ChestInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;

    [SerializeField] private CoinManager coinManager;
    
    private int isOpenHash;

    private Tween _loopTween;
    private Tween _collectTween;
    
    [SerializeField] private AudioClip chestSound;
    

    void Start()
    {
        if(!anim) return;

        isOpenHash = Animator.StringToHash("IsOpen");
        
        transform.DOScale(2f, 0.5f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }

    public void OnHoverIn()
    {
        Debug.Log("Interact in!");
        anim?.SetBool(isOpenHash, true);

        // TODO - Show UI
        Toast.Instance.ShowToast("Press \"E\" To Interact!");
    }

    public void OnHoverOff()
    {
        anim?.SetBool(isOpenHash, false);
        Debug.Log("Interact out!");

        // TODO - Hide UI
        Toast.Instance.HideToast();
    }

    public void OnInteract()
    {
        Debug.Log($"Interacted with {gameObject.name}");
        transform.DOScale(0, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
        {
            AudioSource.PlayClipAtPoint(chestSound, Vector3.zero);
            Destroy(gameObject);
        });

    }

    void OnDestroy()
    {
        coinManager.AddCoins(5);
        DOTween.Kill(this.gameObject);
    }
} 