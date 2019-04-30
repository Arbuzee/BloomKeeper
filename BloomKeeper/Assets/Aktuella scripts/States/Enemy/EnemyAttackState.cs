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
        base.HandleUpdate();
        owner.agent.SetDestination(owner.player.transform.position);
        Attack();
        if (!CanSeePlayer() || Vector3.Distance(owner.transform.position, owner.player.transform.position) > chaseDistance)
            owner.Transition<EnemyChaseState>();
        else if (CanSeeDecoy())
            owner.Transition<EnemyChasingDecoyState>();
      
    }

    private void Attack()
    {
        currentCool -= Time.deltaTime;

        
        if (currentCool > 0)
            return;

        OnCollision();
        owner.player.Transition<StaggerState>();
        owner.player.GetComponent<Health>().TakeDamage();
        currentCool = cooldown;
    }

 
    public void OnCollision()
    {
        Collider collider = owner.GetComponent<Collider>();
        RaycastHit hit;
        bool collide = Physics.BoxCast(collider.bounds.center, owner.transform.localScale, owner.transform.forward, out hit, Quaternion.identity, 1);
        if (collide && hit.collider.gameObject.CompareTag("Player"))
        {
            PlayerPhysics.instance.PlayerVelocity = owner.player.transform.TransformDirection(Vector3.back) * 100;
        }
    }



}
