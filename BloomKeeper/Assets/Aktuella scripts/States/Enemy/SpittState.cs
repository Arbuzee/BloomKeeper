using UnityEngine;



[CreateAssetMenu(menuName = "Enemy/SpittState")]

public class SpittState : EnemyBaseState
{


    protected float SpitterCD = 5;
    [SerializeField] private GameObject spitt;



    public override void Enter()
    {
        owner.agent.velocity = Vector3.zero;
        Debug.Log("Entering spit state");
    }


    public override void HandleUpdate()
    {

        if (Spitter.CanSpitt)
        {
            GameObject instantiatedSpit = Instantiate(spitt, owner.Mouth.position, Quaternion.identity);
            instantiatedSpit.GetComponent<Rigidbody>().AddForce((owner.player.transform.position - owner.transform.position * 100));
            Spitter.CanSpitt = false;
            owner.gameObject.AddComponent<Timer>().RunTimer("spittimer");
            owner.Transition<EnemyChaseState>();
        }




        //if (!CanSeePlayer() && !CanSeeDecoy() || Vector3.Distance(owner.transform.position, owner.player.transform.position) > lostTargetDistance)
        //    owner.Transition<EnemyPatrolState>();
        if (Vector3.Distance(owner.transform.position, owner.player.transform.position) > attackDistance)
            owner.Transition<EnemyChaseState>();
        else if (CanSeeDecoy())
            owner.Transition<EnemyChasingDecoyState>();


    }


}
