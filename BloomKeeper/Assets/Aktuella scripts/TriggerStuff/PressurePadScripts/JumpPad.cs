using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject Player;
    public float JumpForce = 0;
    public ParticleSystem JumpParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 PadForce = new Vector3(0, JumpForce, 0);
            PlayerPhysics.instance.PlayerVelocity += PadForce;

            ParticleSystem particleInstance = Instantiate(JumpParticle, gameObject.transform.position, Quaternion.Euler(-90,0,0));
            
            Destroy(particleInstance.gameObject, 2f);

        }

    }


}
