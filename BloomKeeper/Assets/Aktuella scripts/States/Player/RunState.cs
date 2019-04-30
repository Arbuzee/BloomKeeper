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
        Movement3D.Instance_3d.collidertest();

        if (!Movement3D.Instance_3d.groundColl())
        {
            owner.Transition<JumpState>();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            owner.Transition<BaseState>();
        }

    }
}
