using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject Player;
    public float JumpForce = 0;
    public ParticleSystem JumpParticle;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 PadForce = new Vector3(0, JumpForce, 0);
            PlayerPhysics.Instance.PlayerVelocity += PadForce;

            //För att undvika att skapa och förstöra objekt som tar relativt mycket arbetskraft 
            //så kan man stänga av loopen på partikel system och bara spela upp via kod när det är dags //Gleb
            //
            //ParticleSystem instance = Instantiate(JumpParticle, transform.position, JumpParticle.transform.rotation);
            //Destroy(instance.gameObject, 3f);
            JumpParticle.Play();

            anim.SetTrigger("Active");
        }

    }


}
