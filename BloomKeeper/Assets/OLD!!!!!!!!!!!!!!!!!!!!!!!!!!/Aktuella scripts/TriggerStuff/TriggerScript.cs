using UnityEngine;
using System;
using System.Collections;

public class TriggerScript : MonoBehaviour
{
    public GameObject TriggerObject;
    public LayerMask layerMask;
    

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            try
            {
               
                TriggerObject.GetComponent<TriggeredObject>().OnTrigger();

            }
            catch (Exception e) { }


        }


    }


    private void OnTriggerExit(Collider other)
    {


        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            try
            {

                TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();

            }
            catch (Exception e) { }


        }


    }

}
