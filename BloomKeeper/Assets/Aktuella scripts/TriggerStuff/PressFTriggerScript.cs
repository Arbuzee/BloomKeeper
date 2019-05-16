using UnityEngine;
using System;
using System.Collections;



public class PressFTriggerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] triggerObject;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] public bool isActivated;
    private bool playerInsideCollider;

    [Header("Lock")]
    [SerializeField] private GameObject lockingObject;
    [SerializeField] private bool isLocked = false;


    [Header("Cables")]
    [SerializeField] private Material deActivatedMaterial;
    [SerializeField] private Material activeMaterial;
    [SerializeField] private bool cabelActive;
    [SerializeField] private GameObject[] cables;

    private void Update()
    {
        setLocked();
        PressLever();
    }

    private void PressLever()
    {
        if (playerInsideCollider)
        {
            if (Input.GetKeyDown(KeyCode.F) && !isActivated && !isLocked)
            {
                try
                {
                    isActivated = true;
                    foreach(GameObject animObject in triggerObject) //startar alla animations objekt i listan
                    {
                        animObject.GetComponent<TriggeredObject>().OnTrigger();
                    }

                    cabelActive = true;
                    activateCable();
                }
                catch (Exception e) { }
                return;
            }
            if (Input.GetKeyDown(KeyCode.F) && isActivated && !isLocked)
            {
                try
                {
                    isActivated = false;
                    foreach (GameObject animObject in triggerObject)
                    {
                        animObject.GetComponent<TriggeredObject>().OnDeTrigger();
                    }


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


    private void setLocked()
    {
        if(lockingObject != null && lockingObject.GetComponent<TriggerScript>().isActive)
        {
            isLocked = true;
        }
        else
        {
            isLocked = false;
            if (!isActivated)
            {
                foreach (GameObject animObject in triggerObject)
                {
                    animObject.GetComponent<TriggeredObject>().OnDeTrigger();
                }
                //triggerObject.GetComponent<TriggeredObject>().OnDeTrigger();
            }
        }
    }


}




