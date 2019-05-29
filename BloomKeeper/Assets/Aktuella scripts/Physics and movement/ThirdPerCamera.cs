using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerCamera : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private float mouseSensitivity = 6f;
    private Quaternion rotation;

    [Range(0, 10)]
    [SerializeField] private float cameraDistance;

    private Vector3 cameraPositionToPlayer;
    private float rotationX;
    public static float rotationY;
    [SerializeField] private float maxAngle = 90f;
    [SerializeField] private float minAngle = -2f;

    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private Transform playerTransform;

    public static ThirdPerCamera Instance;


    Vector3 refVelocity = Vector3.zero;

    private void Awake()
    {

        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);


        cameraPositionToPlayer = new Vector3(0, 1, -cameraDistance);
        //Funkar?? Kanske måste kolla i build
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        //playerTransform.root.eulerAngles = new Vector3(0, rotationY, 0);
        transform.forward = rotation * Vector3.forward;

        RaycastHit hit;
        Physics.SphereCast(playerTransform.position, 0.1f, rotation * cameraPositionToPlayer, out hit, cameraPositionToPlayer.magnitude - 0.5f, collisionLayer);
        

        //if camera hits wall
        if (hit.collider != null)
        {           
            Vector3 hitPoint = hit.point.normalized * (hit.point.magnitude - 0.5f);
            //transform.position = Vector3.Lerp(transform.position, hitPoint, Time.deltaTime * 100);
            transform.position = Vector3.SmoothDamp(transform.position, hitPoint, ref refVelocity , 0.01f);
            
            //transform.position = hitPoint;            
        }
        //if camera doesn't hit wall
        else
        {
            Vector3 cameraPos = playerTransform.position + rotation * cameraPositionToPlayer;
            //transform.position = Vector3.Lerp(transform.position, cameraPos, Time.deltaTime * 100);
            transform.position = Vector3.SmoothDamp(transform.position, cameraPos, ref refVelocity, 0.01f);

            //transform.position = cameraPos;
        }


    }
}

