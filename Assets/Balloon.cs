using UnityEngine;
using DG.Tweening;

public class Balloon : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    
    private bool popped = false;

    void Start()
    {
        coinManager = CoinManager.Instance;
        transform.DOScale(0.8f, 0.8f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (popped) return;
        
        if (collision.gameObject.CompareTag("Arrow") || collision.gameObject.CompareTag("Spell"))
        {
            Pop();
            popped = true;
        }
    }
    void Pop()
    {
        Debug.Log("Pop");
        
        
        if (coinManager != null)
        {
            coinManager.AddCoins(1);
        }

        DOTween.Kill(this.gameObject);
        Destroy(gameObject);
    }
    
}
