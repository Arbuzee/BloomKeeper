using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PressurePad/PressurePadDeactivatedState")]
public class PressurePadDeactivatedState : TriggerStatusState
{
    protected PressurePad owner;

    public override void Initialize(TriggerObjectStateMachine owner)
    {
        this.owner = (PressurePad)owner;
    }

    public override void HandleUpdate()
    {
        if (owner.controllingObject != null)
        {
            //sätt den här pressurepaden till låst i ett visst state
        }


        //Om triggad av en spelare/decoy:
        //Ontriggerenter?
        //owner.transition --> activatedState
        

    }
}
