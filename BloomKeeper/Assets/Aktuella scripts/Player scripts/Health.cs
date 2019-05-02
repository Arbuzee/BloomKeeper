using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private GameObject[] hearts;
    public static int health;
    public Transform Spawn;
    public ParticleSystem hitParticle;
    public void Awake()
    {
        health = hearts.Length;
        //hitParticle.transform.position = gameObject.transform.position;
    }


    public void TakeDamage()
    {
        if (health <= 1) {

            ResetHealth();
            return;
            
        }
           
            

        health--;
        hearts[health].SetActive(false);
        Instantiate(hitParticle, gameObject.transform.position, Quaternion.identity);
        hitParticle.Play(true);

    }




    public void ResetHealth()
    {
        
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
        health = hearts.Length;

        transform.position = Spawn.transform.position;

    }
}
