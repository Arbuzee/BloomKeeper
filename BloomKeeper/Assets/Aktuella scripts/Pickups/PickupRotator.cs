using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotator : MonoBehaviour
{
    [SerializeField] private ParticleSystem onPickUpParticles;

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("collision");
            //add to counter
            CanvasController.Instance.addPickup();
            ParticleSystem particleInstance = Instantiate(onPickUpParticles, transform.position, Quaternion.identity);
            Destroy(particleInstance.gameObject, 2.5f);
            Destroy(gameObject);
        }
    }
}
