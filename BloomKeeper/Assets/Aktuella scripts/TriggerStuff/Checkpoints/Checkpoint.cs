using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public int checkpointIndex;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (CheckPointSave.currentCheckpointIndex < checkpointIndex)
        {
            CheckPointSave.SavePlayer(other.gameObject);
            CheckPointSave.currentCheckpointIndex = checkpointIndex;
        }

    }





}
