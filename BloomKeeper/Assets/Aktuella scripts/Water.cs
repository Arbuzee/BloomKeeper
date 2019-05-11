using UnityEngine;

public class Water : MonoBehaviour
{

    public Transform spawnPoint;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = spawnPoint.position;
        }
    }

}
