using UnityEngine;
using System;
using System.Collections;

public class TriggerScript : MonoBehaviour
{
    public GameObject TriggerObject;
    public LayerMask layerMask;
    public bool playerActivated = false;
    public bool decoyActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerActivated = true;
            try
            {
                TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
                //colliderCheck();
            }
            catch (Exception e) { }

        }

        if (other.gameObject.CompareTag("Decoy"))
        {
            decoyActive = true;
            try
            {
                TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
                //colliderCheck();
            }
            catch (Exception e) { }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && other.CompareTag("Player") )
        {
            playerActivated = false;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && other.CompareTag("Decoy"))
        {
            decoyActive = false;
        }

        if(!decoyActive && !playerActivated)
        {
            doTriggerExit();
            Debug.Log("exit");
        }

    }

    public void doTriggerExit()
    {
       
            try
            {
                TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
            }
            catch (Exception e) { }

    }



}
