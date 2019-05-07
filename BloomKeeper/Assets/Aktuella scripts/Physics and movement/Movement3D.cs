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
    public AudioClip decoyAudio;

    
    [SerializeField] public Vector3 jumpforce = new Vector3(0, 7f, 0);

    private Vector3 boxSize2;
    private Vector3 gravity = new Vector3(0, 0, 0);
    private Vector3 maxVelocity;

    public static Movement3D Instance_3d;

    void Awake()
    {
        Instance_3d = this;
        
    }

    private void Update()
    {
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
            // Make sure it plays decoy sound in the appropriate script, PlayerAnimController
            //SoundManager.instance.PlaySound(decoyAudio);
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
        
        input = transform.TransformDirection(new Vector3(input.x, 0, input.z));
        input = Vector3.ProjectOnPlane(input, PlayerPhysics.Instance.GroundNormal());
        //input.y = 0;
        Debug.DrawRay(transform.position, input.normalized*10);

        //gravity
        float grav = General.gravityForce * Time.deltaTime;
        gravity = Vector3.down * grav;
        PlayerPhysics.Instance.PlayerVelocity += gravity + input;

        //check for max speed
        if (PlayerPhysics.Instance.PlayerVelocity.magnitude > Speed)
        {
            PlayerPhysics.Instance.PlayerVelocity = Vector3.ClampMagnitude(PlayerPhysics.Instance.PlayerVelocity, Speed);
        }
    }

    public void jump()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<PlayerPhysics>().groundColl())
        {
            PlayerPhysics.Instance.PlayerVelocity += jumpforce;
        }
    }


   

    


   

}

