using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPM.CustomPhysics;

public class Elevator : MonoBehaviour
{
    public GameObject elevator;

    private Vector3[] elevatorPositions = new Vector3[2];
    private float startTime, journeyTime = 5, offset = 0.1f;
    private bool runElevator = false;
    private Direction direction = Direction.DOWN;

    private PhysicsComponent physicsComponent;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            runElevator = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            runElevator = false;
            elevator.transform.position = elevatorPositions[0];
            direction = Direction.DOWN;
        }
    }

    public void Start()
    {
        physicsComponent = GetComponent<PhysicsComponent>();
        elevatorPositions[0] = elevator.transform.position;
        elevatorPositions[1] = elevator.transform.position + new Vector3(0, 10, 0);
        runElevator = true;
    }

    public void LateUpdate()
    {
        if (elevator.transform.position.y >= elevatorPositions[1].y - offset && direction == Direction.UP && runElevator)
        {
            direction = Direction.DOWN;
            physicsComponent.SetForce(new Vector3(0,-10,0));
        }
        else if (elevator.transform.position.y <= elevatorPositions[0].y + offset && direction == Direction.DOWN && runElevator)
        {
            direction = Direction.UP;
            physicsComponent.SetForce(new Vector3(0,10,0));
        }
    }

}

public enum Direction
{
    UP, DOWN
}


