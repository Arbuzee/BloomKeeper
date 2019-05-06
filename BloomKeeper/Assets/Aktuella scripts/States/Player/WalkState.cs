﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/WalkState")]
public class WalkState : BaseState
{
    

    public override void Enter()
    {
        Debug.Log("Entering walkstate");
     
    }

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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            owner.Transition<RunState>();
        }

    }
}
