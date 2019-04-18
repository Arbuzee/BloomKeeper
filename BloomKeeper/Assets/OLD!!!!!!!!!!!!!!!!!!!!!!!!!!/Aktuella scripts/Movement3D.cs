using System.Collections;
using System.Collections.Generic;
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

    [Header("Physics")]
    public LayerMask collisionLayer;
    public float gravityForce = 7f;
    public float Speed = 3f;

    [SerializeField] public float skinWidth = 0.2f;
    public float groundCheckDistance = 0.1f;

    public float staticFric = 0.5f;
    public float dynamicFric = 0.4f;
    public float airFric = 0.7f;

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

    Bezier bezier;

    [Header("Camera")]
    public Camera cam3rdPerson;
    private float mouseSensitivity = 6f;
    Quaternion rotation;

    [Range(0,10)]
    public float cameraDistance;

    private Vector3 cameraPositionToPlayer;
    private float rotationX;
    private float rotationY;
    [SerializeField] private float maxAngle = 90f;
    [SerializeField] private float minAngle = -10f;

    void Awake()
    {
        bezier = gameObject.AddComponent<Bezier>();
        gameObject.AddComponent<LineRenderer>();
        
        cameraPositionToPlayer = new Vector3(0, 1, -cameraDistance);
        Instance_3d = this;
        //boxSize2 = gameObject.GetComponent<BoxCollider>().size;
        capsuleSize = gameObject.GetComponent<CapsuleCollider>().radius;
        capsule = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        capsule1 = transform.position + capsule.center + Vector3.up * -capsule.height * skinWidth;
        capsule2 = capsule1 + Vector3.up * capsule.height;
    }
   

    Vector3 inputVelocity(float Speed)
    {
        float xAx = Input.GetAxisRaw("Horizontal");
        float zAx = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(xAx, 0.0f, zAx);
        float distance = Speed * Time.deltaTime;
        return direction * distance;
    }
    public void CameraInput()
    {
        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");

        rotationX -= y * mouseSensitivity;
        rotationY += x * mouseSensitivity;

        rotationX = Mathf.Clamp(rotationX, minAngle, maxAngle);
        rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }


    public void CameraMovementThirdPerson()
    {
        transform.eulerAngles = new Vector3(0, rotationY, 0);
        cam3rdPerson.transform.forward = rotation * Vector3.forward;

        RaycastHit hit;
        Physics.SphereCast(transform.position, 0.5f, rotation * cameraPositionToPlayer, out hit, cameraPositionToPlayer.magnitude - 0.5f, collisionLayer);
        Vector3 hitPoint = hit.point - new Vector3(1f, 0f, 1f);
        //Vector3 newVector = new Vector3(hitPoint.x - 1, hitPoint.y - 1);

        if (hit.collider != null)
        {
            cam3rdPerson.transform.position = hitPoint;
        }
        else
        {
            Vector3 cameraPos = transform.position + rotation * cameraPositionToPlayer;
            cam3rdPerson.transform.position = cameraPos;
        }
    }

    public void SetDecoy()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bezier = gameObject.AddComponent<Bezier>();
            gameObject.AddComponent<LineRenderer>();
            
        }
        if (Input.GetKey(KeyCode.Q)) {
            
            bezier.DrawBezier(dropPoint);

        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            decoy.Execute(dropPoint);
            Destroy(GetComponent<LineRenderer>());
        }
    }

    public void walk(float Speed)
    {
        
        //movement input
        Vector3 input = inputVelocity(Speed);
        //  input = input.normalized;

        //following the camera orientation

        input = cam3rdPerson.transform.rotation * input;
        //input = Vector3.ProjectOnPlane(input, GroundNormal());
        //input = input.normalized;
        input.y = 0;


        //gravity
        float grav = gravityForce * Time.deltaTime;
        gravity = Vector3.down * grav;
        //print("Vad visar gravity.y: " + gravity.y);
        //print("Vad visar gravity + input.normalized.y: " + new Vector3(gravity.x + input.normalized.x, gravity.y + input.normalized.y).y);

        //velocity += gravity + input.normalized;
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
        //Physics.BoxCast(transform.position, boxSize2 / 2, Vector3.down, out hit, transform.rotation, groundCheckDistance, collisionLayer);
        Physics.CapsuleCast(capsule1, capsule2, capsuleSize, Vector3.down, out hit, groundCheckDistance, collisionLayer);
        return hit.normal;
    }

    public void collidertest()
    {
        for (int i = 0; i < 20; i++)
        {
            RaycastHit colliderHit;
            Debug.DrawRay(transform.position, PlayerVelocity.normalized, Color.cyan);
            //if (Physics.BoxCast(transform.position, boxSize2 / 2, velocity.normalized, out colliderHit, transform.rotation, velocity.magnitude * Time.deltaTime + skinWidth, collisionLayer))
            if (Physics.CapsuleCast(capsule1, capsule2, capsuleSize, PlayerVelocity.normalized, out colliderHit, PlayerVelocity.magnitude * Time.deltaTime + skinWidth, collisionLayer))
            {
                Vector3 normal = colliderHit.normal;
                Vector3 projection = General.normalKraft3d(PlayerVelocity, normal);
                transform.position += PlayerVelocity.normalized * (colliderHit.distance - skinWidth);
                PlayerVelocity += projection;
                PlayerVelocity = friction(projection);
                PlayerVelocity = airFriction(PlayerVelocity);
            }
        }
        //DEBUG
        Debug.DrawRay(transform.position, PlayerVelocity.normalized, Color.green);
        transform.position += PlayerVelocity * Time.deltaTime;
    }

    Vector3 friction(Vector3 projection)
    {

        Vector3 frictionV;
        if (PlayerVelocity.magnitude < (staticFric * projection.magnitude))
        {
            frictionV = new Vector3(0, 0, 0);
        }
        else
        {
            frictionV = PlayerVelocity + -PlayerVelocity.normalized * (dynamicFric * projection.magnitude);
        }
        return frictionV;
    }

    Vector3 airFriction(Vector3 velocity)
    {

        return velocity *= Mathf.Pow(airFric, Time.deltaTime);
    }

    public bool groundColl()
    {
        RaycastHit gColliderHit;

        //if (Physics.BoxCast(transform.position, boxSize2 / 2, Vector3.down, out gColliderHit, transform.rotation, groundCheckDistance, collisionLayer))
        if (Physics.CapsuleCast(capsule1, capsule2, capsuleSize, Vector3.down, out gColliderHit, groundCheckDistance, collisionLayer))
        {
            return true;
        }
        return false;
    }

}
