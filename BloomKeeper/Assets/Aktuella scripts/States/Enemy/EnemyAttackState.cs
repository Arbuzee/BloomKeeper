using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Enemy/EnemyAttackState")]
public class EnemyAttackState : EnemyBaseState
{
    // Attributes
    [SerializeField] private float chaseDistance;
    Animator animator;
    private bool hasAttacked;
    float attackCooldown = 2.5f;

    private float activateColliderSeconds = 2.5f;

    private Vector3 dirToPlayer;
    private float lookRotationSpeed = 10f;

    // Methods
    public override void Enter()
    {
        base.Enter();
        owner.GetComponentInChildren<EnemyColliderCheck>().RegisterOnHitPlayer(OnCollision);
        animator = owner.GetComponentInChildren<Animator>();
        owner.agent.velocity = Vector3.zero;
        owner.AttackCollider.enabled = true;

    }

    public override void Exit()
    {
        base.Exit();
        owner.GetComponentInChildren<EnemyColliderCheck>().UnRegisterOnHitPlayer(OnCollision);
        owner.AttackCollider.enabled = false;
        //owner.agent.isStopped = false;
        //owner.agent.speed = 2.5f;
    }

    public override void HandleUpdate()
    {



        if (attackCooldown <= 0)
        {
            Attack();
            attackCooldown = 2.5f;
            //owner.AttackCollider.enabled = true;
            //hasAttacked = true;
        }

        RoatateToPlayer();


        attackCooldown -= Time.deltaTime;
        if (!CanSeePlayer() || hasAttacked == true ||Vector3.Distance(owner.transform.position, owner.player.transform.position) > chaseDistance)
        {
            owner.Transition<EnemyChaseState>();
            hasAttacked = false;
        }else if (CanSeeDecoy())
            owner.Transition<EnemyChasingDecoyState>();

    }

    private void Attack()
    {
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < attackDistance)
        {
            hasAttacked = true;
            owner.AttackCollider.enabled = true;

            animator.SetTrigger("AttackTrigger"); // Triggers the animation            animator.SetTrigger("AttackTrigger"); // Triggers the animation
        }


    }


    public void OnCollision()
    {
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) > attackDistance)
            return;

        //owner.player.GetComponent<Health>().TakeDamage();
        PlayerPhysics.Instance.PlayerVelocity = Camera.main.transform.TransformDirection(new Vector3(0,100,-300)); //Blir alltid pushad bakåt för spelaren. dvs om man står riktad framåt så flyger man fortfarande bakåt.
        Debug.Log("Collision");
    }

    //IEnumerator attackColliderCooldown()
    //{
    //    Debug.Log("hey");
    //    owner.AttackCollider.enabled = true;
    //    new WaitForSeconds(2.5f);
    //    owner.AttackCollider.enabled = false;
    //    yield return null;
    //}

    private void AttackColliderHandeler() //används inte
    {
        if (hasAttacked)
        {
            owner.AttackCollider.enabled = true;
            if (activateColliderSeconds >= 0)
            {
                activateColliderSeconds -= Time.deltaTime;
            }
            else
            {
                owner.AttackCollider.enabled = false;
            }
        }
        
    }


    private void RoatateToPlayer()
    {
        dirToPlayer = (owner.player.transform.position - owner.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dirToPlayer.x, 0f, dirToPlayer.z));
        owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }

    //private void RotateTowards(Transform target)
    //{
    //    Vector3 direction = (target.position - transform.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(direction);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    //}


}



//else
//{
//    hasAttacked = false;
//}

//AttackColliderHandeler();

//else
//{
//    hasAttacked = false;
//    owner.AttackCollider.enabled = false;
//}


//if (hasAttacked)
//{
//    owner.AttackCollider.enabled = true;
//}
//else
//{
//    owner.AttackCollider.enabled = false;
//}