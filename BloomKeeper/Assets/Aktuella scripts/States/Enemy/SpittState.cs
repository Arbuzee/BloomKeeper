using UnityEngine;



[CreateAssetMenu(menuName = "Enemy/SpittState")]

public class SpittState : EnemyBaseState
{


    protected float SpitterCD = 5;
    [SerializeField] private GameObject spitt;
    private float attackCooldown = 1.5f;
    private bool hasSpat;
    private Vector3 dirToPlayer;
    private float lookRotationSpeed = 10f;

    public override void Enter()
    {
        animator = owner.GetComponentInChildren<Animator>();

        owner.agent.velocity = Vector3.zero;
        Debug.Log("Entering spit state");
        animator.SetTrigger("Attack");
        hasSpat = false;
    }


    public override void HandleUpdate()
    {

        //if (Spitter.CanSpitt)
        //{

        if (attackCooldown <= 0)
        {
            SpittAttack();
            attackCooldown = 1.5f;
        }
        //else
        //{
        //    hasSpat = false;
        //}


        owner.agent.velocity = Vector3.zero;
        RoatateToPlayer();
        attackCooldown -= Time.deltaTime;



        //}




        //if (!CanSeePlayer() && !CanSeeDecoy() || Vector3.Distance(owner.transform.position, owner.player.transform.position) > lostTargetDistance)
        //    owner.Transition<EnemyPatrolState>();
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) > attackDistance && hasSpat)
        {
            hasSpat = false;
            owner.Transition<EnemyChaseState>();
        }
        else if (CanSeeDecoy())
            owner.Transition<EnemyChasingDecoyState>();


    }


    private void SpittAttack()
    {

        GameObject instantiatedSpit = Instantiate(spitt, owner.Mouth.position, Quaternion.identity);
        instantiatedSpit.GetComponent<Rigidbody>().AddForce((owner.player.transform.position - owner.transform.position) * 100); // här är din kod, den sköt mot prefabens position
        Spitter.CanSpitt = false;
        owner.gameObject.AddComponent<Timer>().RunTimer("spittimer");
        owner.Transition<EnemyChaseState>();
        hasSpat = true;

    }


    private void RoatateToPlayer()
    {
        dirToPlayer = (owner.player.transform.position - owner.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dirToPlayer.x, 0f, dirToPlayer.z));
        owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }

}
