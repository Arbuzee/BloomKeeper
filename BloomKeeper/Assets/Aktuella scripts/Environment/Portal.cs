using UnityEngine;

public class Portal : MonoBehaviour
{

    public GameObject portalOut;

    private static bool isActive = true;


    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if(isActive)
        {
            StartCoroutine("ResetPortal");
            
            other.transform.position = portalOut.transform.position;
        }
        
    }

    private void test()
    {
        isActive = false;
        //yield return new WaitForSeconds(2.0f);
        isActive = true;
    }
}
