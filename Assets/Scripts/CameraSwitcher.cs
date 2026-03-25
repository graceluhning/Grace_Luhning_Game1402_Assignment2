using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineCamera exploreCamera;
    [SerializeField] private CinemachineCamera aimCamera;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject playerMesh;

    void OnEnable()
    {
        playerController.OnStateUpdated += SwitchCamera;   
    }

    void OnDisable()
    {
        playerController.OnStateUpdated -= SwitchCamera;   
    }

    private void SwitchCamera(PlayerState state)
    {
        switch(state)
        {
            case PlayerState.EXPLORE:
               
                exploreCamera.Prioritize();
                
                if (playerMesh != null)
                    playerMesh.SetActive(true);
                break;
            case PlayerState.AIM:
                
                aimCamera.Prioritize();
                
                if (playerMesh != null)
                    playerMesh.SetActive(false);
                break;
            default:
                //NOTHING TO DO HERE
                break;
        }
    }
}