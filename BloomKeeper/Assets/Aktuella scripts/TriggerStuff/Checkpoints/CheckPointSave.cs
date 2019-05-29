using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CheckPointSave
{

    public static int currentCheckpointIndex = 0;

    public static void SavePlayer(GameObject player)
    {
        PlayerPrefs.SetInt("GameSaved", 1);
        PlayerPrefs.SetInt("SceneIndex", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetFloat("YRoation", player.transform.eulerAngles.y);

        PlayerPrefs.SetFloat("XPosition", player.transform.position.x);
        PlayerPrefs.SetFloat("YPosition", player.transform.position.y);
        PlayerPrefs.SetFloat("ZPosition", player.transform.position.z);
    }

    public static void LoadPlayer(GameObject player)
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneIndex"));

        float xPosition = PlayerPrefs.GetFloat("XPosition");
        float yPosition = PlayerPrefs.GetFloat("YPosition");
        float zPosition = PlayerPrefs.GetFloat("ZPosition");

        float yRotation = PlayerPrefs.GetFloat("YRotation");

        Vector3 position = new Vector3(xPosition, yPosition, zPosition);
        Vector3 rotation = new Vector4(0, yRotation, 0);

        player.transform.position = position;
        player.transform.eulerAngles = rotation;


    }






}
