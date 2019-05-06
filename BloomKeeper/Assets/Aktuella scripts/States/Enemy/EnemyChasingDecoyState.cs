using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyChaseDecoyState")]
public class EnemyChasingDecoyState : EnemyBaseState
{

    public override void HandleUpdate()
    {
        if (Movement3D.Instance_3d.decoy.GetInstance())
        {

            owner.agent.SetDestination(Movement3D.Instance_3d.decoy.GetInstance().transform.position);
        }
        else
        {
            owner.Transition<EnemyChaseState>();
        }

        
    }

}
