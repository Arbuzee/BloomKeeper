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
        Movement3D.Instance_3d.CameraInput();
        Movement3D.Instance_3d.CameraMovementThirdPerson();
        Movement3D.Instance_3d.walk(moveSpeed);
        
        Movement3D.Instance_3d.collidertest();
        if (Movement3D.Instance_3d.groundColl())
        {
            owner.Transition<BaseState>();
        }
    }
}
