using UnityEngine;

public class Portal : MonoBehaviour
{

    public GameObject portalOut;



    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        other.transform.position = portalOut.transform.position; 
    }








}
