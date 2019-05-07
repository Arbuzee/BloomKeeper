using UnityEngine;



[CreateAssetMenu(menuName = "Enemy/SpittState")]

public class SpittState : EnemyBaseState
{


    protected float SpitterCD = 5;
    Vector3 playerPos;
    public GameObject spitt;



    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entering spit state");
    }


    public override void HandleUpdate()
    {
       
            
            GameObject instantiatedSpit = Instantiate(spitt, owner.Mouth.position, Quaternion.identity);
            instantiatedSpit.GetComponent<Rigidbody>().AddForce((owner.player.transform.position - owner.transform.position) * 100);

            Spitter.CanSpitt = false;
            owner.gameObject.AddComponent<Timer>().RunTimer("spittimer");
        
        if (!CanSeePlayer() && !CanSeeDecoy() || Vector3.Distance(owner.transform.position, owner.player.transform.position) > lostTargetDistance)
            owner.Transition<EnemyPatrolState>();
        else if (Vector3.Distance(owner.transform.position, owner.player.transform.position) < attackDistance)
            owner.Transition<EnemyChaseState>();
        else if (CanSeeDecoy())
            owner.Transition<EnemyChasingDecoyState>();


    }


}
