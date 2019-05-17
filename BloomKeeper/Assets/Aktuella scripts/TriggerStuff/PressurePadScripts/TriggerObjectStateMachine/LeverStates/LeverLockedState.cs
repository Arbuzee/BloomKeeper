using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lever/LeverLockedState")]
public class LeverLockedState : TriggerBaseState
{
    public override void Enter()
    {
        Debug.Log("LeverLockedState -> enter ");

    }
    public override void Exit()
    {
        Debug.Log("LeverLockedState -> exit ");

    }
    public override void FixedHandelUpdate()
    {
        if (!owner.LockObject.isActive)
        {
            if (!owner.isActive)
            {
                owner.Transition<LeverDeActivatedState>();
            }
            else
            {
                owner.Transition<LeverActivatedState>();
            }
        }
    }
}
