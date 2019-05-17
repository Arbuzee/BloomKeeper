using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lever/LeverDeActivatedState")]
public class LeverDeActivatedState : TriggerBaseState
{
    public override void Enter()
    {
        Debug.Log("LeverDeActiveState -> enter ");
        if (owner.AnimObject != null)
        {
            foreach (GameObject animGO in owner.AnimObject)
            {
                animGO.GetComponent<TriggeredObject>().OnDeTrigger();
            }
        }
        owner.isActive = false;
    }
    public override void Exit()
    {
        Debug.Log("LeverDeActiveState -> exit ");

    }

    public override void FixedHandelUpdate()
    {
        if (BoxCheck())
        {
            isInLeverRange = true;
        }
        else
        {
            isInLeverRange = false;
        }

    }

    public override void HandleUpdate()
    {
        if (owner.LockObject != null)
        {
            if (owner.LockObject.isActive)
            {
                owner.Transition<LeverLockedState>();
            }
        }
        if (isInLeverRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                owner.Transition<LeverActivatedState>();
            }
        }
    }
}
