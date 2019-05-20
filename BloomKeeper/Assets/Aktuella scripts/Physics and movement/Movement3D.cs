using UnityEngine.UI;
using UnityEngine;



public class Movement3D : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private int HP = 3;
    [SerializeField] private Vector3 jumpforce = new Vector3(0, 7f, 0);
    //[SerializeField] private Transform SpawnPoint;

    [Header("Enemy")]
    [SerializeField] private GameObject enemy;

    [Header("Attack")]
    [SerializeField] public Ability Decoy;
    [SerializeField] private Transform dropPoint;
    [SerializeField] private float forceMultiplier, forceStep;
    [SerializeField] private Image forceMeter;
    [SerializeField] private AudioClip decoyAudio;

    private Vector3 boxSize2;
    private Vector3 gravity = new Vector3(0, 0, 0);
    private float gravityForce = 20f;
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


    private Vector3 inputVelocity(float Speed)
    {
        float xAx = Input.GetAxisRaw("Horizontal");
        float zAx = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(xAx, 0.0f, zAx);
        float distance = Speed * Time.deltaTime;
        return direction * distance;
    }

    //Method for executing decoy with force multiplier
    //private void SetDecoy()
    //{

    //    if (Input.GetKey(KeyCode.Q) && forceMultiplier < 1)
    //    {
            
    //        forceMultiplier += forceStep * Time.deltaTime;
    //        forceMeter.fillAmount = forceMultiplier;
    //    }
    //    else if (Input.GetKeyUp(KeyCode.Q))
    //    {
    //        // Make sure it plays decoy sound in the appropriate script, PlayerAnimController
    //        //SoundManager.instance.PlaySound(decoyAudio);
    //        Decoy.Execute(dropPoint, forceMultiplier);
    //        forceMultiplier = 0;
    //        forceMeter.fillAmount = 0;

    //    }
    //}

    //Method for executing decoy without force
    private void SetDecoy()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Decoy.Execute(dropPoint);
        }
        Switcheroo();
    }

    private void Switcheroo()
    {
        if (Input.GetKeyDown(KeyCode.R) && GameObject.FindGameObjectWithTag("Decoy"))
        {
            GameObject decoy = GameObject.FindGameObjectWithTag("Decoy");
            GameObject temporaryPosition = new GameObject();
            temporaryPosition.transform.position = transform.position;
            transform.position = decoy.transform.position + new Vector3(0, 2, 0);
            decoy.transform.position = temporaryPosition.transform.position;
            DestroyImmediate(temporaryPosition);
        }
    }

    public void walk(float Speed)
    {

        //movement input
        Vector3 input = inputVelocity(Speed);

        input = transform.TransformDirection(new Vector3(input.x, 0, input.z));
        input = Vector3.ProjectOnPlane(input, PlayerPhysics.Instance.GroundNormal());

        //gravity
        float grav = gravityForce * Time.deltaTime;
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

