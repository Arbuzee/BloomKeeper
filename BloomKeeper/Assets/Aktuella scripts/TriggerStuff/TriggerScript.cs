using UnityEngine;
using System;
using System.Collections;

public class TriggerScript : MonoBehaviour
{
    public GameObject TriggerObject;
    public bool playerActivated = false;
    public bool decoyActive = false;

    [Header("Cabels")]
    public Material deActivatedMaterial;
    public Material activeMaterial;
    public bool cabelActive;
    public GameObject [] cables ;


    private void OnTriggerEnter(Collider other)
    {

        

        if (other.CompareTag("Player"))
        {
            
            playerActivated = true;
            try
            {
                TriggerObject.GetComponent<TriggeredObject>().OnTrigger();

                
            }
            catch (Exception e) { }
            activateCable();
            cabelActive = true;
        }

        if (other.gameObject.CompareTag("Decoy"))
        {
            decoyActive = true;
            try
            {
                TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
                
            }
            catch (Exception e) { }
            cabelActive = true;
            activateCable();

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
            cabelActive = false;
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
        deActivateCabel();

    }

    private void activateCable()
    {
        foreach(GameObject cabel in cables)
        {
            cabel.GetComponent<Renderer>().material = activeMaterial;
        }
    }

    private void deActivateCabel()
    {
        foreach(GameObject cabel in cables)
        {
            cabel.GetComponent<Renderer>().material = deActivatedMaterial;
        }
    }
}
