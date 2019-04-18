using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SPM.CustomPhysics
{

    public class PhysicsManager : MonoBehaviour
    {
        public static PhysicsManager Instance;
        public static float EARTH_GRAVITY = 9.82f;

        public static Vector3 Gravity()
        {

            float acceleration = EARTH_GRAVITY * Time.deltaTime;
            Vector3 gravity = Vector3.down * acceleration;
            return gravity;

        }

        public static Vector3 GroundPush()
        {

            return -Gravity();

        }


        public void Awake()
        {
            if (Instance == null)
                Instance = this;

            else if (Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }



    }
}


