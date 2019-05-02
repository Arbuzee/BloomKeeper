using UnityEngine;
using System.Collections;
using System;

public class DecoyBehaviour : MonoBehaviour
{
    private bool move = false;

    private GameObject pressurePad;

    public void Start()
    {
        

        DestroyDecoy();
        StartCoroutine(timer(5));
    }

    public IEnumerator timer(float t) {
        
        yield return new WaitForSeconds(t);

        Destroy(gameObject);
        
    }

    public void DestroyDecoy() {

        GameObject[] decoys = GameObject.FindGameObjectsWithTag("Decoy");

        foreach (GameObject decoy in decoys) {

            if (gameObject == decoy)
                return;

            Destroy(decoy);

        }

    }

    private void OnDestroy()
    {

        try
        {
            pressurePad.GetComponent<TriggerScript>().doTriggerExit();
            pressurePad.GetComponent<TriggerScript>().decoyActive = false;
        }
        catch(Exception e) { }

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PressurePad"))
        {
            pressurePad = other.gameObject;
        }
    }


}
