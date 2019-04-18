using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{


    public static General instance;

    private void Awake()
    {
        instance = this;
    }

    public static Vector2 normalKraft2d(Vector2 velocity, Vector2 normal)
    {
        
        Debug.Log("normalkraft");
        float skalärprodukt = Vector2.Dot(velocity, normal);
        if (Vector2.Dot(velocity, normal) > 0)
        {
            skalärprodukt = 0;
        }
        Vector2 projection = skalärprodukt * normal;


        return -projection;
    }



    public static Vector3 normalKraft3d(Vector3 velocity, Vector3 normal)
    {
        float skalärprodukt = Vector3.Dot(velocity, normal);
        if(Vector3.Dot(velocity,normal) >= 0)
        {
            skalärprodukt = 0;
        }
        Vector3 projection = skalärprodukt * normal;
        return -projection;
    }
}