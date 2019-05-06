using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationState : MonoBehaviour
{

    public GameObject ObjectToTrigger;

    public GameObject object1, object2, object3;
    


public void checkRightState()
    {
        if(object1.GetComponent<RotatePillar>().rightState ==true && object2.GetComponent<RotatePillar>().rightState == true && object3.GetComponent<RotatePillar>().rightState == true)
        {
            ObjectToTrigger.GetComponent<TriggeredObject>().OnTrigger();
        }
        else
        {
            ObjectToTrigger.GetComponent<TriggeredObject>().OnDeTrigger();
        }
    }
}
