using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyChaseState")]
public class EnemyChaseState : EnemyBaseState
{

    // Attributes
    //[SerializeField] private float attackDistance;
    //[SerializeField] private float lostTargetDistance;
    public bool decoy = false;
    // Methods

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("ChaseState");
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        //if (CanSeeDecoy())
        //{
        //    //owner.agent.isStopped = true;

        //    //owner.agent.SetDestination(Movement3D.Instance_3d.clone.transform.position);
        //    owner.Transition<EnemyChasingDecoyState>();
        //}

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
        else if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < attackDistance)
        {
            owner.Transition<EnemyAttackState>();
        }           
        Charge();
    }

    private void Charge()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("collider trigger");
    //    if (other.CompareTag("Player"))
    //    {
    //        owner.Transition<EnemyProneState>();
    //    }
    //    if (other.CompareTag("Log"))
    //    {
    //        owner.Transition<EnemyProneState>();
    //    }

    //    }

    }
