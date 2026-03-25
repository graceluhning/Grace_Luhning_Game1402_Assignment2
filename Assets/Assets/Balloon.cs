using UnityEngine;
using DG.Tweening;

public class Balloon : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private SpawnerBehaviour spawner;
    
    public AudioClip popSound;
    private bool popped = false;


    void Start()
    {
        coinManager = CoinManager.Instance; // set coinManager
        transform.DOScale(0.8f, 0.8f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad); // animate balloon
    }

    public void SetSpawner(SpawnerBehaviour spawnerRef)
    {
        spawner = spawnerRef; // spawner reference
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow") || collision.gameObject.CompareTag("Spell")) // pop only if specific objects collide
        {
            OnPop(); // when destroyed by arrow or spell, call OnPop function
            
        }
    }
    void OnPop()
    {
        Debug.Log("Pop");

        if (popped) return; // check if balloon is popped
        popped = true; // set popped to true
        
        if (coinManager != null) // if there is a coinmanager, add coins
        {
            coinManager.AddCoins();
        }

        if (spawner != null) // run OnBalloonDestroyed function from spawner script
        {
            spawner.OnBalloonDestroyed();
        }
        else
        {
            Debug.LogError("Spawner NULL");
        }
        
        AudioSource.PlayClipAtPoint(popSound, transform.position); // play audio, kill tween and destroy balloon
        DOTween.Kill(this.gameObject);
        Destroy(gameObject);
        
    }
    
}
