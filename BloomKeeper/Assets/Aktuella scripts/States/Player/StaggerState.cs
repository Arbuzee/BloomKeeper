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
            Debug.Log("To basestate");
            owner.Transition<BaseState>();
        }
    }
}
