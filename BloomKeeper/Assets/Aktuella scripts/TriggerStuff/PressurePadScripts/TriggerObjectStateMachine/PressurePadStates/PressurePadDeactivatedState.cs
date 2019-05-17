using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PressurePad/PressurePadDeactivatedState")]
public class PressurePadDeactivatedState : TriggerBaseState
{

    public override void Enter()
    {
        Debug.Log("PressurePadDeActivated -> enter");
        if(owner.AnimObject != null)
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
        Debug.Log("PressurePadDeActivated -> exit");
    }
    public override void HandleUpdate()
    {
        if (owner.LockObject != null)
        {
            if (owner.LockObject.isActive)
            {
                owner.Transition<PressurePadLockedState>();
            }

        }

        if (BoxCheck())
        {
            owner.Transition<PressurePadActivatedState>();
        }

        //Om triggad av en spelare/decoy:
        //Ontriggerenter?
        //owner.transition --> activatedState


    }
}
