using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCListener : MonoBehaviour
{
    public GameObject textBox;

    private void OnTriggerStay(Collider other)
    {        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F)){
            textBox.SetActive(true);
        }     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && textBox.activeSelf == true)
        {
            textBox.SetActive(false);
        }
    }
}
