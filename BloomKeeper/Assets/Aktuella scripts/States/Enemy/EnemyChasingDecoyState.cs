using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyChaseDecoyState")]
public class EnemyChasingDecoyState : EnemyBaseState
{
    private float cooldown = 3, currentCooldown = 0;
    private bool doneAttack = false;
    
    


    public override void HandleUpdate()
    {
        if (Movement3D.Instance_3d.Decoy.GetInstance())
        {
            GameObject decoy = Movement3D.Instance_3d.Decoy.GetInstance();
            owner.agent.SetDestination(decoy.transform.position);
            if (Vector3.Distance(owner.transform.position, decoy.transform.position) < 3 && !doneAttack)
            {
                decoy.SendMessage("TakeDamage", owner);
                doneAttack = true;
            }
                
        }
        else
        {
            owner.Transition<EnemyChaseState>();
        }

        if (currentCooldown < cooldown && doneAttack)
            currentCooldown += Time.deltaTime;
        else
        {
            doneAttack = false;
            currentCooldown = 0;

        }
            
        
    }

}
