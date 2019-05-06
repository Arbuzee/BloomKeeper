using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorPads : MonoBehaviour
{
    public bool playerInsideTrigger;

    public CheckMaterialCombo checkMaterialCombo;
    private Material tempMaterial;
    public Material material1;
    public Material material2;
    public Material material3;

    private void Awake()
    {
       GetComponentInParent<CheckMaterialCombo>();
    }

    private void Update()
    {
        if(playerInsideTrigger)

        if (Input.GetKeyDown(KeyCode.F))
        {
            tempMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
            //Debug.Log("press1");
            if (tempMaterial.Equals(material1))
            {
                Debug.Log(tempMaterial);
                //Debug.Log("press");
                gameObject.GetComponent<Renderer>().material = material2;
            }
            else if (tempMaterial.Equals(material2))
            {
                Debug.Log(tempMaterial);
                //Debug.Log("press");
                gameObject.GetComponent<Renderer>().material = material3;
            }
            else if (tempMaterial.Equals(material3))
            {
                Debug.Log(tempMaterial);
                //Debug.Log("press");
                gameObject.GetComponent<Renderer>().material = material1;
            }
            Debug.Log("press");

            checkMaterialCombo.checkMaterial();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false ;
        }
    }
    //bool checkIfCorrect()
    //{
    //    if(gameObject.GetComponent<Renderer>().material == material1 && pad1.GetComponent<Renderer>().material == material1 && pad2.GetComponent<Renderer>().material == material1)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}
