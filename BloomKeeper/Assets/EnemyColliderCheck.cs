﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderCheck : MonoBehaviour
{

    private Action onHitPlayer;


    private void OnTriggerEnter(Collider collider)
    {
        //if (true)
        // {
        //     if (onHitPlayer != null)
        //     {
        //         onHitPlayer();
        //     }
        // }



        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerHealth>().TakeDamage();
        } else if (collider.CompareTag("Decoy"))
        {
            collider.GetComponent<DecoyBehaviour>().Explode(transform.root.gameObject.GetComponent<Enemy>());
        }

    }

    public void RegisterOnHitPlayer(Action hitPlayerFunction)
    {
        onHitPlayer += hitPlayerFunction;
        Debug.Log("RegisterOnHitPlayer(Action hitPlayerFunction)");
    }

    public void UnRegisterOnHitPlayer(Action hitPlayerFunction)
    {
        onHitPlayer -= hitPlayerFunction;
    }

}
