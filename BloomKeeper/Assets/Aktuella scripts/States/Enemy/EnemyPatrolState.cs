using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/EnemyPatrolState")]
public class EnemyPatrolState : EnemyBaseState
{
    [SerializeField] private Rigidbody body;

    // Attributes
    [SerializeField] private Vector3[] patrolPoints;
    [SerializeField] private float chaseDistance;
    //[SerializeField] private float attackDistance;
    [SerializeField] private float hearingRange;


    private int currentPoint = 0;

    // Methods
    public override void Enter()
    {
        base.Enter();
        ChooseClosest();
        body = owner.GetComponent<Rigidbody>();
        Debug.Log("Patrol");
       
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();

        owner.agent.SetDestination(patrolPoints[currentPoint]);
        if (Vector3.Distance(owner.transform.position, patrolPoints[currentPoint]) < 5)
            currentPoint = (currentPoint + 1) % patrolPoints.Length;

        if (CanSeePlayer() && Vector3.Distance(owner.transform.position, owner.player.transform.position) < chaseDistance)
            owner.Transition<EnemyChaseState>();
        if (CanSeeDecoy())
            owner.Transition<EnemyChasingDecoyState>();
    }

    private void ChooseClosest()
    {
        int closest = 0;
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            float dist = Vector3.Distance(owner.transform.position, patrolPoints[i]);
            if (dist < Vector3.Distance(owner.transform.position, patrolPoints[closest]))
                closest = i;
        }
        currentPoint = closest;
    }


}
