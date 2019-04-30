using UnityEngine;

public class LogCollider : MonoBehaviour
{

    [SerializeField] public Enemy enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Log"))
        {
            Debug.Log("Log detected");
            enemy.prone = true;

        }
    }
}
