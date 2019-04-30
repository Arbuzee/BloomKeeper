using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject Player;
    public float JumpForce = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 PadForce = new Vector3(0, JumpForce, 0);
            PlayerPhysics.instance.PlayerVelocity += PadForce;
        }

    }


}
