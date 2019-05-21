using UnityEngine;
using System.Collections;
using System;

public class DecoyBehaviour : MonoBehaviour
{
    private bool move = false;
    [SerializeField] private int health = 3;
    [SerializeField] private ParticleSystem damageTaken;

    private GameObject pressurePad;

    public void Start()
    {
        DestroyDecoy();
        StartCoroutine(timer(30));
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

    public void TakeDamage(Enemy enemy)
    {
        if (health > 0)
        {
            health--;
            Instantiate(damageTaken, transform.position, Quaternion.identity);
            
        }
        else
            Explode(enemy);
    }

    public void Explode(Enemy enemy)
    {
        Instantiate(damageTaken, transform.position, Quaternion.identity);
        OnDestroy();
        Destroy(gameObject, 0.1f);
        enemy.Transition<EnemyProneState>();       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PressurePad"))
        {
            pressurePad = other.gameObject;
        }
    }

    /*THIS IS USED FOR GETTING THE Z DISTANCE TO THE DECOY DROP POINT, USED TO SET THE PREVIEW POINT*/

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(Vector3.Distance(transform.position, GameObject.Find("PlayerV2").transform.position));
    //}

}
