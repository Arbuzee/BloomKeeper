using UnityEngine;
using System;
using System.Collections;



public class PressFTriggerScript : MonoBehaviour
{
    public GameObject TriggerObject;
    public LayerMask layerMask;
    public bool isActivated;
    public bool playerInsideCollider;

    [Header("Cables")]
    public Material deActivatedMaterial;
    public Material activeMaterial;
    public bool cabelActive;
    public GameObject[] cables;

    private void Update()
    {
        if (playerInsideCollider)
        {
            if (Input.GetKeyDown(KeyCode.F) && !isActivated)
            {
                try
                {
                    isActivated = true;
                    TriggerObject.GetComponent<TriggeredObject>().OnTrigger();
                    //StartCoroutine(Timer());
                    cabelActive = true;
                    activateCable();
                }
                catch (Exception e) { }
                return;
            }
            if (Input.GetKeyDown(KeyCode.F) && isActivated)
            {
                try
                {
                    isActivated = false;
                    TriggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
                    deActivateCabel();
                    cabelActive = false;

                }
                catch (Exception e) { }
                return;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerInsideCollider = true;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerInsideCollider = false;
        }
    }
    private void activateCable()
    {
        foreach (GameObject cabel in cables)
        {
            cabel.GetComponent<Renderer>().material = activeMaterial;
        }
    }

    private void deActivateCabel()
    {
        foreach (GameObject cabel in cables)
        {
            cabel.GetComponent<Renderer>().material = deActivatedMaterial;
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




