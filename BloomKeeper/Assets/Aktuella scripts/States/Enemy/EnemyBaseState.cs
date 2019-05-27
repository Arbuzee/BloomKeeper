using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Enemy/EnemyBaseState")]
public class EnemyBaseState : EnemyState
{
    // Attributes
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Material material;
    [SerializeField] protected float attackDistance;
    [SerializeField] protected float lostTargetDistance;

    protected Enemy owner;

    // Methods
    public override void Enter()
    {
        //owner.Renderer.material = material;
        owner.agent.speed = moveSpeed;
        //owner.capCollider = owner.GetComponent<CapsuleCollider>();

    }

    public override void HandleUpdate()
    {
        if (owner.prone)
        {
            owner.Transition<EnemyProneState>();
        }
        owner.GetComponentInChildren<Animator>().SetFloat("MovementSpeed", moveSpeed);
    }


    public override void Initialize(EnemyStatemachine owner)
    {
        this.owner = (Enemy)owner;
    }

    protected bool CanSeePlayer()
    {
        return !Physics.Linecast(owner.transform.position, owner.player.transform.position, owner.visionMask);
    }

    protected bool CanSeeDecoy()
    {
        try
        {
            return !Physics.Linecast(owner.transform.position, Movement3D.Instance_3d.Decoy.GetInstance().transform.position, owner.visionMask);
        }
        catch (Exception e) { return false; }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("collider trigger");
    //    if (other.CompareTag("Player"))
    //    {
    //        owner.Transition<EnemyProneState>();
    //    }
    //}
    }
