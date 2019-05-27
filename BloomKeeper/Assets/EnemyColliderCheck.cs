using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderCheck : MonoBehaviour
{

    private Action onHitPlayer;


    private void OnTriggerEnter(Collider collider)
    {
       if (true)
        {
            if (onHitPlayer != null)
            {
                onHitPlayer();
            }
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
