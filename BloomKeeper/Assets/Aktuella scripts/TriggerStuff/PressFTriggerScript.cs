using UnityEngine;
using System;
using System.Collections;



public class PressFTriggerScript : MonoBehaviour
{
    public GameObject TriggerObject;
    public LayerMask layerMask;
    public bool active;


    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && !active)
            {
                try
                {
                    active = true;
                    TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
                    //StartCoroutine(Timer());

                }
                catch (Exception e) { }
                return;
            }
            if (Input.GetKeyDown(KeyCode.F) && active)
            {
                try
                {
                    active = false;
                    TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
                    //StartCoroutine(Timer());

                }
                catch (Exception e) { }
                return;
            }
        }


    }

    //public IEnumerator Timer()
    //{
    //    if(timer == 999)
    //{
    //    yield break;
    //}
    //    yield return new WaitForSeconds(timer);
    //    TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
    //}


}




