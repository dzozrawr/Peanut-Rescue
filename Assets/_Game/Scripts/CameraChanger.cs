using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class CameraChanger : MonoBehaviour
{
    public CinemachineVirtualCamera frontCamera, backCamera;
    // Start is called before the first frame update
    void Start()
    {
        frontCamera.Priority--;
        backCamera.Priority++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
