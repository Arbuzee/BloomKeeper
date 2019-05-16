using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class PickupRotator : MonoBehaviour
    {
        [SerializeField] private ParticleSystem onPickUpParticles;
        [SerializeField] private AudioClip pickupSound;

        void Update()
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {

                SoundEvent soundevent = new SoundEvent();
                soundevent.sound = pickupSound;
                soundevent.FireEvent();

                Debug.Log("collision");
                //add to counter
                CanvasController.Instance.addPickup();
                ParticleSystem particleInstance = Instantiate(onPickUpParticles, transform.position, Quaternion.identity);
                Destroy(particleInstance.gameObject, 2.5f);
                Destroy(gameObject);

            }
        }
    }
}
