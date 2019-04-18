using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public BoxCollider cameraCollider;

    public void Awake()
    {
        cameraCollider = GetComponent<BoxCollider>();
    }

    public void Update()
    {
        
    }
}
