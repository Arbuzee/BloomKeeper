﻿using System.Collections;
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
        ThirdPerCamera.Instance.CameraInput();
        ThirdPerCamera.Instance.CameraMovementThirdPerson();
        Movement3D.Instance_3d.walk(moveSpeed);
        
        PlayerPhysics.instance.collidertest();
        if (PlayerPhysics.instance.groundColl())
        {
            owner.Transition<BaseState>();
        }
    }
}
