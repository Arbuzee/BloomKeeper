using UnityEngine;
using System.Collections;

public class DecoyBehaviour : MonoBehaviour
{


    public void Start()
    {
        DestroyDecoy();
        StartCoroutine(timer());
    }

    public void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("Enemy"))
        //    Destroy(gameObject);
    }

    public IEnumerator timer() {

        yield return new WaitForSeconds(10);
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


   



}
