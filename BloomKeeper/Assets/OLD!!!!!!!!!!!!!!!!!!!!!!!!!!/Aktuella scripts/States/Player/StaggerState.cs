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
        //owner.transform.position += -Movement3D.Instance_3d.EnemyDirection.normalized * 100f;
        //förflytta spelare här
        Debug.Log("Stagger");
        owner.Renderer.material = material;
       
    }

    public override void HandleUpdate()
    {
        ThirdPerCamera.Instance.CameraInput();
        ThirdPerCamera.Instance.CameraMovementThirdPerson();

        wait += Time.deltaTime;
        if(wait > cooldown)
        {
            owner.Transition<BaseState>();
        }
    }
}
