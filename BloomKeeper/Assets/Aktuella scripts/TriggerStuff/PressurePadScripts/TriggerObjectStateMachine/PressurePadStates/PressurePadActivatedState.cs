using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PressurePad/PressurePadActivatedState")]
public class PressurePadActivatedState : TriggerBaseState
{
    public override void Enter()
    {
        Debug.Log("PressurePadActivatedState -> Enter");
    }

    public override void Exit()
    {
        Debug.Log("PressurePadActivatedState -> Exit");
    }

    public override void FixedHandelUpdate()
    {

        if (!PlayerDecoyColliding())
        {
            owner.Transition<PressurePadDeactivatedState>();
        }

        //if (PlayerDecoyColliding())
        //{
        //    Debug.Log("PlayerDecoyColliding == true");
        //}
        //else
        //{
        //    Debug.Log("PlayerDecoyColliding == false");
        //}

        //if(boxOverlap().Length > 0)
        //{
        //    foreach (Collider collider in boxOverlap())
        //    {
        //        Debug.Log(collider.name);
        //    }
        //}
        //else
        //{
        //    Debug.Log("boxOverlapp.length = 0");
        //}
            

    }
}
