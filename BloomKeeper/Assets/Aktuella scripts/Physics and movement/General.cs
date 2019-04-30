using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class General
{

    private static float staticFric = 0.23f;
    private static float dynamicFric = 0.19f;
    private static float airFric = 0.05f;
    public static float gravityForce = 19.3f;

    public static Vector3 normalKraft3d(Vector3 velocity, Vector3 normal)
    {
        float skalärprodukt = Vector3.Dot(velocity, normal);
        if (Vector3.Dot(velocity, normal) >= 0)
        {
            skalärprodukt = 0;
        }
        Vector3 projection = skalärprodukt * normal;
        return -projection;
    }

    public static Vector3 friction(Vector3 projection, Vector3 PlayerVelocity)
    {
        Vector3 frictionV;
        if (PlayerVelocity.magnitude < (staticFric * projection.magnitude))
        {
            frictionV = new Vector3(0, 0, 0);
        }
        else
        {
            frictionV = PlayerVelocity + -PlayerVelocity.normalized * (dynamicFric * projection.magnitude);
        }
        return frictionV;
    }

    public static Vector3 airFriction(Vector3 velocity)
    {
        return velocity *= Mathf.Pow(airFric, Time.deltaTime);
    }
}
