using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSave : MonoBehaviour
{

    private Player playerInstance;

    [SerializeField] private GameObject[] checkPoints;

    [SerializeField] private int checkPointCounter = 0;

    private void Awake()
    {
        playerInstance = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInstance = other.GetComponent<Player>();



        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(playerInstance);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        playerInstance.health = data.PlayerHealth;

        Vector3 savedPosition;
        savedPosition.x = data.PlayerPosition[0];
        savedPosition.y = data.PlayerPosition[1];
        savedPosition.z = data.PlayerPosition[2];

        playerInstance.transform.position = savedPosition;
    }


}
