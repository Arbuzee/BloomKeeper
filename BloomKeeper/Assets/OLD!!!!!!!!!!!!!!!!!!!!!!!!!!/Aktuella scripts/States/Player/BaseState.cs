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
        owner.Renderer.material = material;
    }

    public override void Initialize(PlayerStatemachine owner)
    {
        this.owner = (Player)owner;
    }

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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            owner.Transition<RunState>();
        }

        }
}
