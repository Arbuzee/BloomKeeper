using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public GameObject[] hearts;
    private int health;


    public void Start()
    {
        health = hearts.Length;
    }


    public void TakeDamage()
    {

        health--;
        hearts[health].SetActive(false);

        if (health <= 0)
        {
            RestoreHealth();
            LoadCheckpoint();

        }

    }


    public void RestoreHealth()
    {
        foreach(GameObject heart in hearts)
        {
            heart.SetActive(true);
        }

        health = hearts.Length;

    }

    public void LoadCheckpoint()
    {
        CheckPointSave.LoadPlayer(gameObject);
    }



}
