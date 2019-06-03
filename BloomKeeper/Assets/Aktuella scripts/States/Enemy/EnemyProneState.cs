using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyProneState")]
public class EnemyProneState : EnemyBaseState
{
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


       if (time > Cooldown)
        {
           
            owner.prone = false;
            owner.Transition<EnemyChaseState>();
            return;
        }
        
    }

    public override void Exit()
    {
        owner.prone = false;
        base.Exit();

        time = 0f;
    }
}
