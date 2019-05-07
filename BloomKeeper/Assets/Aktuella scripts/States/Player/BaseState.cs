using UnityEngine;


[CreateAssetMenu(menuName = "Player/BaseState")]
public class BaseState : PlayerState
{
    protected Player owner;
    [SerializeField] protected Material material;
    [SerializeField] protected float moveSpeed;

    public override void Enter()
    {
        Debug.Log("Entering basestate");
        owner.Renderer.material = material;
    }

    public override void Initialize(PlayerStatemachine owner)
    {
        this.owner = (Player)owner;
    }

    

    public override void HandleUpdate()
    {
        owner.Transition<WalkState>();
    }
}
