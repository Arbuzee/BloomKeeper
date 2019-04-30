using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorPads : MonoBehaviour
{
    public Material material1, material2, material3;
    private Material tempMaterial;

    public GameObject pad1, pad2;

    private void Awake()
    {

    }

    private void Update()
    {
        if (checkIfCorrect())
        {
            //Do something
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                tempMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
                Debug.Log("press1");

                if (tempMaterial.Equals(material1))
                {
                    Debug.Log(tempMaterial);
                    Debug.Log("press");
                    gameObject.GetComponent<Renderer>().material = material2;
                }
                else if (tempMaterial.Equals(material2))
                {
                    Debug.Log(tempMaterial);
                    Debug.Log("press");
                    gameObject.GetComponent<Renderer>().material = material3;
                }
                else if (tempMaterial.Equals(material3))
                {
                    Debug.Log(tempMaterial);
                    Debug.Log("press");
                    gameObject.GetComponent<Renderer>().material = material1;
                }
            }
        }
    }

    bool checkIfCorrect()
    {
        if(gameObject.GetComponent<Renderer>().material == material1 && pad1.GetComponent<Renderer>().material == material1 && pad2.GetComponent<Renderer>().material == material1)
        {
            return true;
        }
        return false;
    }
}
