using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Outfit : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera; // The CinemachineFreeLook camera
    public CinemachineVirtualCamera virtualCamera; // The CinemachineVirtualCamera camera
    public bool useFreeLookCamera = true; // Whether to use the free look camera by default

    private void Start()
    {
        // Set the active camera based on the toggle
        if (useFreeLookCamera)
        {
            ActivateFreeLookCamera();
        }
        else
        {
            ActivateVirtualCamera();
        }
    }

    private void Update()
    {
        // Toggle the camera when the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (useFreeLookCamera)
            {
                ActivateVirtualCamera();
            }
            else
            {
                ActivateFreeLookCamera();
            }
        }
    }

    private void ActivateFreeLookCamera()
    {
        freeLookCamera.gameObject.SetActive(true);
        virtualCamera.gameObject.SetActive(false);
        useFreeLookCamera = true;
    }

    private void ActivateVirtualCamera()
    {
        freeLookCamera.gameObject.SetActive(false);
        virtualCamera.gameObject.SetActive(true);
        useFreeLookCamera = false;
    }
}
