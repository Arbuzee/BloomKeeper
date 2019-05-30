using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyChaseState")]
public class EnemyChaseState : EnemyBaseState
{

    private Vector3 playerPos;
    public bool decoy = false;
    // Methods

    public override void Enter()
    {
        base.Enter();
        Debug.Log("ChaseState");

    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        playerPos = owner.player.transform.position;
        //Debug.Log("SetDestination -> chaseState " + playerPos);
        owner.agent.SetDestination(owner.player.transform.position);
        //Debug.Log("SetDestination -> chaseState " + owner.player.transform.position);




        if (!CanSeePlayer() && !CanSeeDecoy() || Vector3.Distance(owner.transform.position, owner.player.transform.position) > lostTargetDistance)
        {
            owner.Transition<EnemyPatrolState>();
        }
        else if (CanSeeDecoy())
        {
            owner.Transition<EnemyChasingDecoyState>();
        }
        if (owner.CompareTag("Spitter"))
        {
            if (Spitter.CanSpitt)
            {
                owner.Transition<SpittState>();
            }
        }
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < attackDistance && owner.CompareTag("Enemy"))
        {
            owner.Transition<EnemyAttackState>();
        }
        else if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < attackDistance && owner.gameObject.name == "Spitter")
        {
            owner.Transition<SpitterAttackState>();
        }

    }





}
