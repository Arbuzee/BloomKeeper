using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PressurePad/PressurePadActivatedState")]
public class PressurePadActivatedState : TriggerBaseState
{

    public override void Enter()
    {
        Debug.Log("PressurePadActivatedState -> Enter");
        if(owner.AnimObject != null)
        {
            foreach (GameObject animGO in owner.AnimObject)
            {
                animGO.GetComponent<TriggeredObject>().OnTrigger();
            }
        }
        
        owner.isActive = true;    
        
    }

    public override void Exit()
    {
        Debug.Log("PressurePadActivatedState -> Exit");
    }

    public override void FixedHandelUpdate()
    {
        if (owner.LockObject != null)
        {
            if (owner.LockObject.isActive)
            {
                owner.Transition<PressurePadLockedState>();
            }
        }
        if (!BoxCheck())
        {
            owner.Transition<PressurePadDeactivatedState>();
        }
    }
}
