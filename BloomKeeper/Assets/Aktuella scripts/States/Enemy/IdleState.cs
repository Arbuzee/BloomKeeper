using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Enemy/EnemyIdleState")]
public class IdleState : EnemyBaseState
{

    public override void Enter()
    {
        base.Enter();

        if (owner.CompareTag("Spitter"))
        {
            owner.Transition<EnemyChaseState>();
            return;
        }
            

        Timer timer = owner.gameObject.AddComponent<Timer>();
        timer.SetupTimer(owner, 1);
        timer.RunTimer("transitiontoattacktimer");
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
    }

    public override void Exit()
    {
        base.Exit();
    }

    

}
