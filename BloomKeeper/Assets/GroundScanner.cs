using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScanner : MonoBehaviour
{
    public GameObject point;
    public LayerMask layerMask;
    public static GroundScanner instance;


    public void Awake()
    {
        if (instance == null)
            instance = this;

        if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        SetGroundHeight();
    }

    public void SetGroundHeight() {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, layerMask) && point.activeSelf)
        {
            point.transform.position = hit.point;
        }

    }



}
