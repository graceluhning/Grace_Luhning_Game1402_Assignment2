using UnityEngine;

public class ShopNPC : MonoBehaviour
{
  public Animator npcAnimator;

  public void OnInteract()
  {
    npcAnimator.SetTrigger("InteractTrigger");
  }
  
}
