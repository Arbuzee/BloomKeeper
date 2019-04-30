using UnityEngine;
using System.Collections;

public class DecoyBehaviour : MonoBehaviour
{


    public void Start()
    {
        

        DestroyDecoy();
        StartCoroutine(timer(5));
    }


    public IEnumerator timer(float t) {
        
        yield return new WaitForSeconds(t);
        moveDecoy(gameObject);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public void DestroyDecoy() {

        GameObject[] decoys = GameObject.FindGameObjectsWithTag("Decoy");

        foreach (GameObject decoy in decoys) {

            if (gameObject == decoy)
                return;

            moveDecoy(decoy);


        }

    }


   private void moveDecoy(GameObject decoy)
    {
        decoy.GetComponent<Collider>().enabled = false;
        decoy.GetComponent<MeshRenderer>().enabled = false;
        decoy.transform.position += new Vector3(0, 100, 0);
    }



}
