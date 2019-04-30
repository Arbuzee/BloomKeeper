using UnityEngine.UI;
using UnityEngine;



public class Movement3D : MonoBehaviour
{
    [Header("Player Stats")]
    public int HP = 3;
    public Transform SpawnPoint;

    public GameObject enemy;
    public Vector3 EnemyDirection;

    [Header("Attack")]
    public Ability decoy;
    public Transform dropPoint;
    public float forceMultiplier, forceStep;
    public Image forceMeter;

    [Header("Physics")]
    public LayerMask collisionLayer;
    public float gravityForce = 7f;
    public float Speed = 3f;

    [SerializeField] public float skinWidth = 0.2f;
    public float groundCheckDistance = 0.1f;

    public Vector3 PlayerVelocity;
    [SerializeField] public Vector3 jumpforce = new Vector3(0, 7f, 0);

    private float capsuleSize;
    private Vector3 capsule1;
    private Vector3 capsule2;
    CapsuleCollider capsule;
    private Vector3 boxSize2;
    private Vector3 gravity = new Vector3(0, 0, 0);
    private Vector3 maxVelocity;

    public static Movement3D Instance_3d;

    void Awake()
    {
        Instance_3d = this;
        capsuleSize = gameObject.GetComponent<CapsuleCollider>().radius;
        capsule = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        capsule1 = transform.position + capsule.center + Vector3.up * -capsule.height * skinWidth;
        capsule2 = capsule1 + Vector3.up * capsule.height;
        SetDecoy();
    }


    Vector3 inputVelocity(float Speed)
    {
        float xAx = Input.GetAxisRaw("Horizontal");
        float zAx = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(xAx, 0.0f, zAx);
        float distance = Speed * Time.deltaTime;
        return direction * distance;
    }


    public void SetDecoy()
    {

        if (Input.GetKey(KeyCode.Q) && forceMultiplier < 1)
        {
            forceMultiplier += forceStep * Time.deltaTime;
            forceMeter.fillAmount = forceMultiplier;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {

            decoy.Execute(dropPoint, forceMultiplier);
            forceMultiplier = 0;
            forceMeter.fillAmount = 0;

        }
    }

    public void walk(float Speed)
    {

        //movement input
        Vector3 input = inputVelocity(Speed);

        //following the camera orientation
        input = ThirdPerCamera.Instance.transform.rotation * input;
        input.y = 0;

        //gravity
        float grav = gravityForce * Time.deltaTime;
        gravity = Vector3.down * grav;
        PlayerVelocity += gravity + input;

        //check for max speed
        if (PlayerVelocity.magnitude > Speed)
        {
            PlayerVelocity = Vector3.ClampMagnitude(PlayerVelocity, Speed);
        }
    }

    public void jump()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && groundColl())
        {
            PlayerVelocity += jumpforce;
        }
    }


    Vector3 GroundNormal()
    {
        RaycastHit hit;
        Physics.CapsuleCast(capsule1, capsule2, capsuleSize, Vector3.down, out hit, groundCheckDistance, collisionLayer);
        return hit.normal;
    }

    public void collidertest()
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

