using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Enemy/EnemyProneState")]
public class EnemyProneState : EnemyBaseState
{
    Vector3 originalRotation = new Vector3(0, 0, 0);
    public Vector3 prone = new Vector3(0 , 0, 90);
    public AudioClip hitSound;

    private float Cooldown = 5f;
    float time = 0f;



    public override void Enter()
    {

        SoundManager.instance.PlaySound(hitSound);
        
    }
    public override void HandleUpdate()
    {
        time += Time.deltaTime;
        owner.gameObject.transform.Rotate(prone, Space.Self);

       if (time > Cooldown)
        {
            //GameController.instance.setFinisherText(false);
            owner.prone = false;
            owner.Transition<EnemyChaseState>();
            return;
        }
        
        if(Vector3.Distance(owner.player.transform.position, owner.transform.position) < 15)
        {
            //GameController.instance.setFinisherText(true);
            if (Input.GetKeyDown(KeyCode.F))
            {

                Destroy(owner.transform.root.gameObject);
                owner.prone = false;
                GameController.instance.setFinisherText(false);
                EnemyCounter.KillEnemy();

                if(EnemyCounter.GetEnemyCount() == 0)
                    GameController.instance.openDoor();
            }
        }
        else
        {
            //GameController.instance.setFinisherText(false);
        }
    }

    public override void Exit()
    {
        owner.prone = false;
        base.Exit();
        
        //GameController.instance.setFinisherText(false);
        owner.gameObject.transform.Rotate(originalRotation, Space.Self);
        time = 0f;
    }
}
