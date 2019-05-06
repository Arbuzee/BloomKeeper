using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Player/BaseState")]
public class BaseState : PlayerState
{
    protected Player owner;
    [SerializeField] protected Material material;
    [SerializeField] protected float moveSpeed;

    public override void Enter()
    {
        Debug.Log("Entering basestate");
        owner.Renderer.material = material;
    }

    public override void Initialize(PlayerStatemachine owner)
    {
        this.owner = (Player)owner;
    }

    //public override void HandleUpdate()
    //{
    //    ThirdPerCamera.Instance.CameraInput();
    //    ThirdPerCamera.Instance.CameraMovementThirdPerson();
    //    Movement3D.Instance_3d.walk(moveSpeed);
    //    Movement3D.Instance_3d.jump();
    //    PlayerPhysics.Instance.collidertest();

    //    if (!PlayerPhysics.Instance.groundColl())
    //    {
    //        owner.Transition<JumpState>();
    //    }
    //    if (Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        owner.Transition<RunState>();
    //    }

    //        }

    public override void HandleUpdate()
    {
        owner.Transition<WalkState>();
    }
}
