using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/RunState")]
public class RunState : BaseState
{
    public override void HandleUpdate()
    {
        Movement3D.Instance_3d.walk(moveSpeed);
        Movement3D.Instance_3d.jump();
        

        if (!PlayerPhysics.Instance.groundColl())
        {
            owner.Transition<JumpState>();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
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
