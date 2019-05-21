using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class DecoyDestroyListener : MonoBehaviour
    {
        void Start()
        {
            DecoyDestroyEvent.RegisterListener(OnDecoyDestroy);
            
        }

        void OnDestroy()
        {
            DecoyDestroyEvent.UnregisterListener(OnDecoyDestroy);
        }

        void OnDecoyDestroy(DecoyDestroyEvent decoyDestroy)
        {
            //send info to pressurepad statemachine etc.
        }
    }
}
