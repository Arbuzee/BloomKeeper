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
                Vector3 projection = normalForce3D(PlayerVelocity, normal);
                transform.position += PlayerVelocity.normalized * (colliderHit.distance - skinWidth);
                PlayerVelocity += projection;
                PlayerVelocity = friction(projection, PlayerVelocity);
                PlayerVelocity = calculateAirFriction(PlayerVelocity);
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


    //From General
    [SerializeField] private float staticFriction = 0.6f;
    [SerializeField] private float dynamicFriction = 0.5f;
    [SerializeField] private float airFriction = 0.1f;

    public Vector3 normalForce3D(Vector3 velocity, Vector3 normal)
    {
        float scale = Vector3.Dot(velocity, normal);
        if (Vector3.Dot(velocity, normal) >= 0)
        {
            scale = 0;
        }
        Vector3 projection = scale * normal;
        return -projection;
    }

    public Vector3 friction(Vector3 projection, Vector3 PlayerVelocity)
    {
        Vector3 frictionVelocity;
        if (PlayerVelocity.magnitude < (staticFriction * projection.magnitude))
        {
            frictionVelocity = new Vector3(0, 0, 0);
        }
        else
        {
            frictionVelocity = PlayerVelocity + -PlayerVelocity.normalized * (dynamicFriction * projection.magnitude);
        }
        return frictionVelocity;
    }

    public Vector3 calculateAirFriction(Vector3 velocity)
    {
        return velocity *= Mathf.Pow(airFriction, Time.deltaTime);
    }

}
