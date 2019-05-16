using UnityEngine;
using System;
using System.Collections;

public class TriggerScript : MonoBehaviour
{
    [SerializeField]public GameObject [] triggerObject;
    public bool playerActivated = false;
    [HideInInspector] public bool decoyActive = false;

    [Header("Lock")]

    [SerializeField] private GameObject lockingObject;
    [SerializeField] public bool isLocked = false;
    public bool isActive;

    [Header("Cables")]

    [SerializeField] private Material deActivatedMaterial;
    [SerializeField] private Material activeMaterial;
    [SerializeField] private GameObject [] cables;


    public void Update()
    {
        setLocked();
    }

    private void OnTriggerEnter(Collider other)
    {

        //om vi vill inte bryr oss om att den ska aktiveras när den är locked -> ta bort isLocked (fråga Sebbe)
        //Finns en bugg där pad:en blir inaktiv när man låser upp spaken (DoExit körs men inte OnEnter så playerActivated/deocyActivated är inte true även om någon av dem står på pad:en). Annars fungerar det som det ska.
        if (other.CompareTag("Player") && !isLocked)
        {
            
            playerActivated = true;
            try
            {

                foreach (GameObject animObject in triggerObject) //startar alla animations objekt i listan
                {
                    animObject.GetComponent<TriggeredObject>().OnTrigger();
                }
            }
            catch (Exception e) { }
            activateCable();
            isActive = true;

        }

        if (other.gameObject.CompareTag("Decoy") && !isLocked)
        {
            decoyActive = true;
            try
            {
                foreach (GameObject animObject in triggerObject)
                {
                    animObject.GetComponent<TriggeredObject>().OnTrigger();
                }

            }
            catch (Exception e) { }
            isActive = true;
            activateCable();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && other.CompareTag("Player"))
        {
            playerActivated = false;
          
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && other.CompareTag("Decoy"))
        {
            decoyActive = false;
            
        }

        if(!decoyActive && !playerActivated && !isLocked)
        {
            doTriggerExit();
            isActive = false;

        }
        
    }

    

    public void doTriggerExit()
    {
       
            try
            {
            foreach (GameObject animObject in triggerObject)
            {
                animObject.GetComponent<TriggeredObject>().OnDeTrigger();
            }
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


    public void setLocked()
    {
        if (lockingObject != null && lockingObject.GetComponent<PressFTriggerScript>().isActivated)
        {
            isLocked = true;
        } else 
        {
            isLocked = false;
            if (!playerActivated && !decoyActive)
            {
                doTriggerExit();
            }
        }
        
    }
}
