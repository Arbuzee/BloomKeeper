using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PressurePad/PressurePadDeactivatedState")]
public class PressurePadDeactivatedState : TriggerBaseState
{

    public override void Enter()
    {
        Debug.Log("PressurePadDeActivated -> enter");
    }

    public override void Exit()
    {
        Debug.Log("PressurePadDeActivated -> exit");
    }
    public override void HandleUpdate()
    {

        if (PlayerDecoyColliding())
        {
            owner.Transition<PressurePadActivatedState>();
        }


        //Om triggad av en spelare/decoy:
        //Ontriggerenter?
        //owner.transition --> activatedState
        

    }
}
