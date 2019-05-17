using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PressurePad/PressurePadLockedState")]
public class PressurePadLockedState : TriggerBaseState
{

    public override void Enter()
    {
        Debug.Log("PressurePadLockState -> enter");

    }

    public override void Exit()
    {
        Debug.Log("PressurePadLockState -> exit");

    }

    public override void FixedHandelUpdate()
    {
        if (!owner.LockObject.isActive)
        {
            if (!BoxCheck())
            {
                owner.Transition<PressurePadDeactivatedState>();
            }
            else
            {
                owner.Transition<PressurePadActivatedState>();
            }
        }
    }

}
