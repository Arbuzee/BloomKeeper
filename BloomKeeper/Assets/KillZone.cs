using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        CheckPointSave.LoadPlayer(other.gameObject);

    }
}
