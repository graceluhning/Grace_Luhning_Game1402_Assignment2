using UnityEngine;
using UnityEngine.Rendering;

public abstract class NPC : MonoBehaviour
{
    void Move()
    {
        Debug.Log("Moving");
    }

    void Interact()
    {
        Debug.Log("Interact");
    }

    void Damage()
    {
        Debug.Log("Damage");
    }

}
