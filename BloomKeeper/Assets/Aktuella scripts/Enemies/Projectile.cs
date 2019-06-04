using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Projectile : MonoBehaviour
{
    //private Spitter spitter;
    [SerializeField] private GameObject player;
     //private Vector3 playerPos;

    private void Awake()
    {
        //playerPos = spitter.GetComponent<Spitter>().player.transform.position;
    }

    private void Start()
    {

        Debug.Log(player.transform.position);
        StartCoroutine(LifeTimer());
        //GetComponent<Rigidbody>().AddForce((player.transform.position - gameObject.transform.position ) * 100);


    }

    private void Update()
    {
        //gameObject.transform.position += player.transform.position * Time.deltaTime * 1; //tänkte att all rörelse skulle ske i projektilen, så gjorde vi innan tror jag

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


        other.GetComponent<PlayerHealth>().TakeDamage();
        PlayerPhysics.Instance.PlayerVelocity = Camera.main.transform.TransformDirection(new Vector3(0, 100, -300));

    }
    //ett försök till något jag inte kommer ihåg 

    //public void SetPlayerLocation(Transform playerTrans)
    //{
    //    Vector3 playerPos = playerTrans.position;
        
    //}

}
