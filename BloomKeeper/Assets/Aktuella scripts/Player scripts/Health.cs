﻿using UnityEngine;

public class Health : MonoBehaviour
{

    public ParticleSystem HitParticle;
    public Transform hitpos;
    [SerializeField] private GameObject[] hearts;
    public static int health;
    public AudioClip hitAudio;


    public void Awake()
    {
        health = hearts.Length;
    }


    public void TakeDamage()
    {
        SoundManager.instance.PlaySound(hitAudio);
        if (health <= 1) {

            ResetHealth();
            return;

        }
           
            

        health--;
        ParticleSystem particleInstance = Instantiate(HitParticle, hitpos.position, Quaternion.identity);
        //hearts[health].SetActive(false);
        Destroy(particleInstance.gameObject, 1.5f);

    }




    public void ResetHealth()
    {
        
        foreach (GameObject heart in hearts)
        {
            //heart.SetActive(true);
        }
        health = hearts.Length;

       // transform.position = GameObject.Find("PlayerSpawnPoint").transform.position;

    }
}
