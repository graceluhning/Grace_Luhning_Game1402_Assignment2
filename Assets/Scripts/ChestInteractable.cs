using UnityEngine;
using DG.Tweening;


public class ChestInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;

    [SerializeField] private CoinManager coinManager;
    
    [SerializeField] private int coins = 5;

    public AudioClip chestSound;
    
    private int isOpenHash;

    private Tween _loopTween;
    private Tween _collectTween;

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

        
        Toast.Instance.ShowToast("Press \"E\" To Interact!");
    }

    public void OnHoverOff()
    {
        anim?.SetBool(isOpenHash, false);
        Debug.Log("Interact out!");
        
        Toast.Instance.HideToast();
    }

    public void OnInteract()
    {
        Debug.Log($"Interacted with {gameObject.name}");
        transform.DOScale(0, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
        {
            AudioSource.PlayClipAtPoint(chestSound, transform.position);
            Destroy(gameObject);
        });

    }

    void OnDestroy()
    {
        coinManager.AddCoins(coins);
        DOTween.Kill(this.gameObject);
    }
} 