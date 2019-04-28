using UnityEngine;
using System;
using System.Collections;

public class TriggerScript : MonoBehaviour
{
    public GameObject TriggerObject;
    public LayerMask layerMask;
    public float timer;
    



    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            try
            {
               
                TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
                if(timer != 0)
                    StartCoroutine(Timer());

            }
            catch (Exception e) { }


        }


    }


    private void OnTriggerExit(Collider other)
    {


        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && timer == 0)
        {

            try
            {

                TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();

            }
            catch (Exception e) { }


        }


    }



    public IEnumerator Timer()
    {

        yield return new WaitForSeconds(timer);
        TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
    }


}
