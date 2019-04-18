using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/RunState")]
public class RunState : BaseState
{
    public override void HandleUpdate()
    {
        Movement3D.Instance_3d.CameraInput();
        Movement3D.Instance_3d.CameraMovementThirdPerson();
        Movement3D.Instance_3d.walk(moveSpeed);
        Movement3D.Instance_3d.jump();
        Movement3D.Instance_3d.collidertest();
        Movement3D.Instance_3d.SetDecoy();
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
