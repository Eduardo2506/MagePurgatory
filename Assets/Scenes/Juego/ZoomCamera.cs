using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public float initialOrthoSize = 3f;
    void Start()
    {
        CinemachineVirtualCamera camera = GetComponent<CinemachineVirtualCamera>();
        if (camera != null)
        {
            camera.m_Lens.OrthographicSize = initialOrthoSize;
        }
    }

}
