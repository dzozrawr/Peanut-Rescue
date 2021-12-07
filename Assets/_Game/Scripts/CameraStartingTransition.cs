using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraStartingTransition : MonoBehaviour
{
    public CinemachineVirtualCamera cM;
    private float endZ, speed=5f, startZ;
    
    
    // Start is called before the first frame update
    void Start()
    {
        endZ = cM.GetCinemachineComponent<Cinemachine3rdPersonFollow>().ShoulderOffset.z;
        startZ = -endZ;
        cM.GetCinemachineComponent<Cinemachine3rdPersonFollow>().ShoulderOffset.z = startZ;
    }

    // Update is called once per frame
    void UpdateMe()
    {
        cM.GetCinemachineComponent<Cinemachine3rdPersonFollow>().ShoulderOffset = new Vector3(0, 0, speed);
        if (cM.GetCinemachineComponent<Cinemachine3rdPersonFollow>().ShoulderOffset.z< startZ)
        {
            cM.GetCinemachineComponent<Cinemachine3rdPersonFollow>().ShoulderOffset.z = startZ;
           // Destroy(this);
        }
    }
}
