using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerCamera : MonoBehaviour
{
    [Header("Camera")]
    //public Camera cam3rdPerson;
    private float mouseSensitivity = 6f;
    Quaternion rotation;

    [Range(0, 10)]
    public float cameraDistance;

    private Vector3 cameraPositionToPlayer;
    private float rotationX;
    private float rotationY;
    public float maxAngle = 90f;
    public float minAngle = -2f;

    public LayerMask collisionLayer;
    public Transform playerTransform;

    public static ThirdPerCamera Instance;

    public void Awake()
    {
        cameraPositionToPlayer = new Vector3(0, 1, -cameraDistance);
        Instance = this;
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
        playerTransform.eulerAngles = new Vector3(0, rotationY, 0);
        transform.forward = rotation * Vector3.forward;

        RaycastHit hit;
        Physics.SphereCast(playerTransform.position, 0.5f, rotation * cameraPositionToPlayer, out hit, cameraPositionToPlayer.magnitude - 0.5f, collisionLayer);
        Vector3 hitPoint = hit.point - new Vector3(1f, 0f, 1f);

        if (hit.collider != null)
        {
            transform.position = hitPoint;
        }
        else
        {
            Vector3 cameraPos = playerTransform.position + rotation * cameraPositionToPlayer;
            transform.position = cameraPos;
        }
    }
}

