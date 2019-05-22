using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Enemy/EnemyAttackState")]
public class EnemyAttackState : EnemyBaseState
{
    // Attributes
    [SerializeField] private float chaseDistance;
    [SerializeField] private float cooldown = 2f;
    [SerializeField] private float freezPostime = 2f;

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
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < 3)
        {
            OnCollision();
            owner.GetComponentInChildren<Animator>().SetTrigger("AttackTrigger"); // Triggers the animation
            owner.player.GetComponent<Health>().TakeDamage();
            owner.Transition<IdleState>();
        }
    }

 
    public void OnCollision()
    {
        
            PlayerPhysics.Instance.PlayerVelocity = Camera.main.transform.TransformDirection(new Vector3(0,100,-300)); //Blir alltid pushad bakåt för spelaren. dvs om man står riktad framåt så flyger man fortfarande bakåt.


    }

   

}
