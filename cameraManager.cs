using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCamera;
    public void Awake()
    {
        mainCamera = Camera.main;
    }
}
