using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/RunState")]
public class RunState : BaseState
{
    public override void HandleUpdate()
    {
        ThirdPerCamera.Instance.CameraInput();
        ThirdPerCamera.Instance.CameraMovementThirdPerson();
        Movement3D.Instance_3d.walk(moveSpeed);
        Movement3D.Instance_3d.jump();
        PlayerPhysics.Instance.collidertest();

        if (!PlayerPhysics.Instance.groundColl())
        {
            owner.Transition<JumpState>();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            owner.Transition<BaseState>();
        }

    }
}
