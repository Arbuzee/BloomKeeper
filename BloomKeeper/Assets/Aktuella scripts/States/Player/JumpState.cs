using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/JumpState")]
public class JumpState : BaseState
{

    public override void Enter()
    {
      
    }


    public override void HandleUpdate()
    {
        Movement3D.Instance_3d.walk(moveSpeed);
        
        if (PlayerPhysics.Instance.groundColl())
        {
            owner.Transition<WalkState>();
        }
    }

    public override void HandleFixedUpdate()
    {
        base.HandleFixedUpdate();
        PlayerPhysics.Instance.Collidertest();
    }

    public override void HandleLateUpdate()
    {
        base.HandleLateUpdate();
        ThirdPerCamera.Instance.CameraInput();
        ThirdPerCamera.Instance.CameraMovementThirdPerson();
    }
}
