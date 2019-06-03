using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy/EnemyPatrolState")]
public class EnemyPatrolState : EnemyBaseState
{
    [SerializeField] private Rigidbody body;

    // Attributes
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

        owner.agent.SetDestination(owner.PatrolPoints[currentPoint].position);
        if (Vector3.Distance(owner.transform.position, owner.PatrolPoints[currentPoint].position) < 5)
            currentPoint = (currentPoint + 1) % owner.PatrolPoints.Length;

        if (CanSeePlayer() && Vector3.Distance(owner.transform.position, owner.player.transform.position) < chaseDistance)
            owner.Transition<EnemyChaseState>();
        if (CanSeeDecoy())
            owner.Transition<EnemyChasingDecoyState>();
    }

    private void ChooseClosest()
    {
        int closest = 0;
        for (int i = 0; i < owner.PatrolPoints.Length; i++)
        {
            float dist = Vector3.Distance(owner.transform.position, owner.PatrolPoints[i].position);
            if (dist < Vector3.Distance(owner.transform.position, owner.PatrolPoints[closest].position))
                closest = i;
        }
        currentPoint = closest;
    }


}
