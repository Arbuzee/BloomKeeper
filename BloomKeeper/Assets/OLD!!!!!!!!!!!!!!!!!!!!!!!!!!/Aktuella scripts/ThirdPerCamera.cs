using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerCamera : MonoBehaviour
{

    public LayerMask layerMask;
    //Kamera
    //public Camera cam1stPerson;
    public Camera cam3rdPerson;
    private float mouseSensitivity = 6f;
    Quaternion rotation;
    private Vector3 cameraPositionToPlayer = new Vector3(0, 1, -3);
    private float rotationX;
    private float rotationY;
    private float maxAngle = 90f;
    private float minAngle = -10f;

    private void Update()
    {
        CameraInput();
        CameraMovementThirdPerson();
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
        cam3rdPerson.transform.forward = rotation * Vector3.forward;
        RaycastHit hit;
        Physics.SphereCast(transform.position, 0.5f, rotation * cameraPositionToPlayer, out hit, cameraPositionToPlayer.magnitude - 0.5f, layerMask);
        if (hit.collider != null)
        {
            cam3rdPerson.transform.position = hit.point;
        }
        else
        {
            Vector3 cameraPos = transform.position + rotation * cameraPositionToPlayer;
            cam3rdPerson.transform.position = cameraPos;
        }
    }
}
