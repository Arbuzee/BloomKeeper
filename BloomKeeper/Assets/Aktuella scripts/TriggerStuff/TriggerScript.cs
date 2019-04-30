using UnityEngine;
using System;
using System.Collections;

public class TriggerScript : MonoBehaviour
{
    public GameObject TriggerObject;
    public LayerMask layerMask;
    public bool activated = false;
    public bool decoyActive = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            activated = true;
            try
            {
                TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
                activated = true;
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
                activated = true;
                //colliderCheck();
            }
            catch (Exception e) { }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && other.CompareTag("Player") )
        {
            activated = false;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && other.CompareTag("Decoy"))
        {
            decoyActive = false;
        }

        if(!decoyActive && !activated)
        {
            doTriggerExit();
            Debug.Log("exit");
        }

    }

    private void doTriggerExit()
    {
       
            try
            {
                TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
            }
            catch (Exception e) { }
   
    }
    //Raycast för att titta efter spelare/decoy, osäker om detta funkar bra 
    //då det blir svårt att kontinuerligt raycasta efter träff men bara trigga bron en gång
    public void colliderCheck()
    {


}
