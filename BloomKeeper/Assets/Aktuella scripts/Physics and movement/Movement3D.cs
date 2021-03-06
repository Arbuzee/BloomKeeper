﻿using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


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
    [Header("Decoy")]
    [SerializeField] private AudioClip decoyAudio;
    [Range(0, 0.25f)]
    [SerializeField] private float decoyForce;
    [SerializeField] private GameObject decoyPreviewPoint;

    private Vector3 boxSize2;
    private Vector3 gravity = new Vector3(0, 0, 0);
    private float gravityForce = 20f;
    private Vector3 maxVelocity;

    public static Movement3D Instance_3d;


    private bool onCooldown = false;

    void Awake()
    {
        if (Instance_3d == null)
            Instance_3d = this;

        if (Instance_3d != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
    }

    private void Update()
    {
        SetDecoy();
        SetRotation();


        if (Input.GetKeyDown(KeyCode.Return))
        {

            SceneManager.LoadScene(0);
        }
            
    }

    public void SetRotation()
    {
        transform.root.eulerAngles = new Vector3(0, ThirdPerCamera.rotationY, 0);
    }

    private Vector3 inputVelocity(float Speed)
    {
        float xAx = Input.GetAxisRaw("Horizontal");
        float zAx = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(xAx, 0.0f, zAx);
        float distance = Speed * Time.deltaTime;
        return direction * distance;
    }


    //Method for executing decoy without force
    private void SetDecoy()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            decoyPreviewPoint.SetActive(true);  
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {

            if (!onCooldown)
            {
                StartCoroutine(Cooldown());

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1))
                {
                    Decoy.Execute(hit.point);
                }
                else
                {
                    Decoy.Execute(dropPoint, decoyForce);
                }

            }
          
            decoyPreviewPoint.SetActive(false);

        }
        Switcheroo();
    }

    private void Switcheroo()
    {
        if (Input.GetKeyDown(KeyCode.R) && GameObject.FindGameObjectWithTag("Decoy") && PlayerPhysics.Instance.groundColl())
        {
            GameObject decoy = GameObject.FindGameObjectWithTag("Decoy");
            GameObject temporaryPosition = new GameObject();
            temporaryPosition.transform.position = transform.position;
            transform.position = decoy.transform.position + new Vector3(0, 1, 0);
            decoy.transform.position = temporaryPosition.transform.position;
            DestroyImmediate(temporaryPosition);
        }
    }


    public IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(1.5f);
        onCooldown = false;
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
        if (PlayerPhysics.Instance.PlayerVelocity.magnitude > 10)
        {
            PlayerPhysics.Instance.PlayerVelocity = Vector3.ClampMagnitude(PlayerPhysics.Instance.PlayerVelocity, 10);
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

