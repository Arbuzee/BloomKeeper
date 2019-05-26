using UnityEngine;


[CreateAssetMenu(menuName = "Player/BaseState")]
public class BaseState : PlayerState
{
    protected PlayerStateOwner owner;
    [SerializeField] protected Material material;
    [SerializeField] protected float moveSpeed;

    public override void Enter()
    {
        owner.Renderer.material = material;
    }

    public override void Initialize(PlayerStatemachine owner)
    {
        this.owner = (PlayerStateOwner)owner;
    }

    

    public override void HandleUpdate()
    {
        owner.Transition<WalkState>();
    }

    
}
