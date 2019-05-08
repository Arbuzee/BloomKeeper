using UnityEngine;


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
           
            owner.prone = false;
            owner.Transition<EnemyChaseState>();
            return;
        }
        
    }

    public override void Exit()
    {
        owner.prone = false;
        base.Exit();
        
        owner.gameObject.transform.Rotate(originalRotation, Space.Self);
        time = 0f;
    }
}
