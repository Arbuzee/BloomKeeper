using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/StaggerState")]
public class StaggerState : BaseState
{
    private float wait = 0f;
    private float cooldown = 2f;

    public override void Enter()
    {
        wait = 0;
        Debug.Log("Stagger");
        owner.Renderer.material = material;
       
    }

    public override void HandleUpdate()
    {
        ThirdPerCamera.Instance.CameraInput();
        ThirdPerCamera.Instance.CameraMovementThirdPerson();

        if (PlayerPhysics.Instance.groundColl())
            Movement3D.Instance_3d.walk(0);

        else Movement3D.Instance_3d.walk(moveSpeed);

        PlayerPhysics.Instance.collidertest();

        wait += Time.deltaTime;
        if(wait > cooldown)
        {
            Debug.Log("To walkstate");
            owner.Transition<WalkState>();
        }
    }
}
