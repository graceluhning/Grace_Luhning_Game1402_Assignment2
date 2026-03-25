using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    public Animator npcAnimator; 

    public void OnInteract()
    {
        if (npcAnimator != null)
        {
            npcAnimator.SetTrigger("InteractTrigger"); // makes the npc wave when the shop is interacted with!
        }
        else
        {
            Debug.LogError("NPC Animator is not assigned!");
        }
    }
}
