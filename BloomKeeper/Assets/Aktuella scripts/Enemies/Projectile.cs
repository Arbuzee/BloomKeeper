using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Projectile : MonoBehaviour
{


    public void Start()
    {
        StartCoroutine(LifeTimer());
    }

    public IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;


        other.GetComponent<Player>().TakeDamage();
        PlayerPhysics.Instance.PlayerVelocity = Camera.main.transform.TransformDirection(new Vector3(0, 100, -300));

    }

}
