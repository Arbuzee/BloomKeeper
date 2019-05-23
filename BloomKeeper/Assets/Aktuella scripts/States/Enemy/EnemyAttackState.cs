using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Enemy/EnemyAttackState")]
public class EnemyAttackState : EnemyBaseState
{
    // Attributes
    [SerializeField] private float chaseDistance;
    Animator animator;

    float attackCooldown = 2.5f;
    // Methods
    public override void Enter()
    {
        base.Enter();
        owner.GetComponentInChildren<EnemyColliderCheck>().RegisterOnHitPlayer(OnCollision);
        animator = owner.GetComponentInChildren<Animator>();

    }

    public override void Exit()
    {
        base.Exit();
        owner.GetComponentInChildren<EnemyColliderCheck>().UnRegisterOnHitPlayer(OnCollision);
    }

    public override void HandleUpdate()
    {

        //base.HandleUpdate();
        //owner.agent.SetDestination(owner.player.transform.position);
        //Hur få att inte röra sig??

        if (attackCooldown <= 0)
        {
            Attack();
            attackCooldown = 2.5f;
        }

        attackCooldown -= Time.deltaTime;

        if (!CanSeePlayer() || Vector3.Distance(owner.transform.position, owner.player.transform.position) > chaseDistance)
            owner.Transition<EnemyChaseState>();
        else if (CanSeeDecoy())
            owner.Transition<EnemyChasingDecoyState>();

    }

    private void Attack()
    {
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < 3)
        {
            animator.SetTrigger("AttackTrigger"); // Triggers the animation
        }


    }


    public void OnCollision()
    {
        //owner.player.GetComponent<Health>().TakeDamage();
        PlayerPhysics.Instance.PlayerVelocity = Camera.main.transform.TransformDirection(new Vector3(0,100,-300)); //Blir alltid pushad bakåt för spelaren. dvs om man står riktad framåt så flyger man fortfarande bakåt.
        Debug.Log("Collision");
    }



}
