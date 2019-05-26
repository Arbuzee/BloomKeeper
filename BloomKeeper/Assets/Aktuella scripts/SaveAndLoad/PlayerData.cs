using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    //[SerializeField] private GameObject player;
    

    public int CurrentCheckPoint;
    public int PlayerHealth;
    public float[] PlayerPosition;
    public float[] PlayerRotation;

    public PlayerData (Player player)
    {
        PlayerHealth = player.health;

        PlayerPosition = new float[3];
        PlayerPosition[0] = player.transform.position.x;
        PlayerPosition[1] = player.transform.position.y;
        PlayerPosition[2] = player.transform.position.z;

        PlayerRotation[0] = player.transform.rotation.x;
        PlayerRotation[1] = player.transform.rotation.y;
        PlayerRotation[2] = player.transform.rotation.z;

    }

}
