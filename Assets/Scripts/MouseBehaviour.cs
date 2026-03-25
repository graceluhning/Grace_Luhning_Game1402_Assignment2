using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    
    void Start()
    {
        ShowMouse(false);
    }

    public void ShowMouse(bool value)
    {
        Cursor.visible = value; // enable mouse on showmouse called
        Cursor.lockState = value ?  CursorLockMode.Locked : CursorLockMode.None;
    }
}
