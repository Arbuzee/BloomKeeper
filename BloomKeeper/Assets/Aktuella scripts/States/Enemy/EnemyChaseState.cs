using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyChaseState")]
public class EnemyChaseState : EnemyBaseState
{


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


        owner.agent.SetDestination(owner.player.transform.position);


        
        if (!CanSeePlayer() && !CanSeeDecoy() || Vector3.Distance(owner.transform.position, owner.player.transform.position) > lostTargetDistance)
        {
            owner.Transition<EnemyPatrolState>();
        }
        else if (CanSeeDecoy())
        {
            owner.Transition<EnemyChasingDecoyState>();
        }            
        else if (owner.CompareTag("Spitter"))
        {
            if (Spitter.CanSpitt)
            {
                owner.Transition<SpittState>();
            }
        }
        else if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < attackDistance && !owner.CompareTag("Spitter"))
        {
            owner.Transition<EnemyAttackState>();
        }           
        Charge();
    }

    private void Charge()
    {

    }



    }
