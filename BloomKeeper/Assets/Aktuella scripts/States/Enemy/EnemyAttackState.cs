using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAttackState")]
public class EnemyAttackState : EnemyBaseState
{
    // Attributes
    [SerializeField] private float chaseDistance;
    [SerializeField] private float cooldown = 2f;

    [SerializeField] private float currentCool;

    // Methods
    public override void Enter()
    {
        base.Enter();
        currentCool = cooldown;
        
    }

    public override void HandleUpdate()
    {
        if (currentCool > 0)
            currentCool -= Time.deltaTime;
        else
            Attack();


        base.HandleUpdate();
        owner.agent.SetDestination(owner.player.transform.position);
        if (!CanSeePlayer() || Vector3.Distance(owner.transform.position, owner.player.transform.position) > chaseDistance)
            owner.Transition<EnemyChaseState>();
        else if (CanSeeDecoy())
            owner.Transition<EnemyChasingDecoyState>();
      
    }

    private void Attack()
    {
        OnCollision();
        owner.player.GetComponent<Health>().TakeDamage();
        currentCool = cooldown;
    }

 
    public void OnCollision()
    {
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < 3)
        {
            PlayerPhysics.Instance.PlayerVelocity = owner.player.transform.TransformDirection(new Vector3(0,100,100));
            owner.player.Transition<StaggerState>();
        }
    }



}
