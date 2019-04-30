using UnityEngine;
using System;
using System.Collections;

public class TriggerScript : MonoBehaviour
{
    public GameObject TriggerObject;
    public LayerMask layerMask;
    public bool activated;
    

    private void OnTriggerEnter(Collider other)
    {      
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.CompareTag("Decoy"))
        {
            try
            {               
                TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
                activated = true;
            }
            catch (Exception e) { }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.CompareTag("Decoy"))
        {
            try
            {
                TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
                activated = false;
            }
            catch (Exception e) { }
        }
    }

    //Raycast för att titta efter spelare/decoy, osäker om detta funkar bra 
    //då det blir svårt att kontinuerligt raycasta efter träff men bara trigga bron en gång
    void checkForPressure()
    {
        RaycastHit hit;
        Physics.BoxCast(TriggerObject.GetComponent<BoxCollider>().size, TriggerObject.GetComponent<BoxCollider>().size / 2, Vector3.up, out hit, transform.rotation, 20, layerMask);
        if(hit.collider.tag == "Decoy" || hit.collider.tag == "Player")
        {

        }
    }


}
