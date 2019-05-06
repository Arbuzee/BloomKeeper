using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{

    [Header("Physics")]
    public LayerMask collisionLayer;
    public float Speed = 3f;

    private Vector3 capsule1, capsule2;
    CapsuleCollider capsule;
    private float capsuleSize;

    [SerializeField] public float skinWidth;
    public float groundCheckDistance;
    public Vector3 PlayerVelocity;


    public static PlayerPhysics Instance;


    public Vector3 GroundNormal()
    {
        RaycastHit hit;
        Physics.CapsuleCast(capsule1, capsule2, capsuleSize, Vector3.down, out hit, groundCheckDistance, collisionLayer);
        return hit.normal;
    }

    public void Awake()
    {
        Instance = this;
        capsuleSize = gameObject.GetComponent<CapsuleCollider>().radius;
        capsule = GetComponent<CapsuleCollider>();
    }


    public void FixedUpdate()
    {
        capsule1 = transform.position + capsule.center + Vector3.up * -capsule.height * skinWidth;
        capsule2 = capsule1 + Vector3.up * capsule.height;
    }

    public void Collidertest()
    {
        for (int i = 0; i < 20; i++)
        {
            RaycastHit colliderHit;
            if (Physics.CapsuleCast(capsule1, capsule2, capsuleSize, PlayerVelocity.normalized, out colliderHit, PlayerVelocity.magnitude * Time.deltaTime + skinWidth, collisionLayer))
            {
                Vector3 normal = colliderHit.normal;
                Vector3 projection = General.normalKraft3d(PlayerVelocity, normal);
                transform.position += PlayerVelocity.normalized * (colliderHit.distance - skinWidth);
                PlayerVelocity += projection;
                PlayerVelocity = General.friction(projection, PlayerVelocity);
                PlayerVelocity = General.airFriction(PlayerVelocity);
            }
        }
        transform.position += PlayerVelocity * Time.deltaTime;
    }

    public bool groundColl()
    {
        RaycastHit gColliderHit;
        if (Physics.CapsuleCast(capsule1, capsule2, capsuleSize, Vector3.down, out gColliderHit, groundCheckDistance, collisionLayer))
        {
            return true;
        }
        return false;
    }


}
