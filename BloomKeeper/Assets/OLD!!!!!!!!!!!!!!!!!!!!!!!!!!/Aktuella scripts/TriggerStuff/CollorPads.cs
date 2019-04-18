using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorPads : MonoBehaviour
{
    public Material material1, material2, material3;
    private Material tempMaterial;
    private void Awake()
    {

        


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







}
