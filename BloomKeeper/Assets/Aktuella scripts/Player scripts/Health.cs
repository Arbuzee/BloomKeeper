using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private GameObject[] hearts;
    public static int health;


    public void Awake()
    {
        health = hearts.Length;
    }


    public void TakeDamage()
    {
        if (health <= 1) {

            ResetHealth();
            return;

        }
           
            

        health--;
        hearts[health].SetActive(false);


    }




    public void ResetHealth()
    {
        
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
        health = hearts.Length;

       // transform.position = GameObject.Find("PlayerSpawnPoint").transform.position;

    }
}
