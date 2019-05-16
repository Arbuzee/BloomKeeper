using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePillar : MonoBehaviour
{
    //public Transform rotateObject;

    public RotationState rotationState;

    private bool insideTrigger;

    public bool state1, state2, state3;

    public bool rightState;
    public Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("State1", true);
        rotationState = GetComponentInParent<RotationState>();
        if (state1)
        {
            rightState = true;
        }
        if (state2)
        {
            rightState = true;
        }

        if (state3)
        {
            rightState = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (insideTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (anim.GetBool("State1") == true)
                {
                    Debug.Log("sate2 true");
                    anim.SetBool("State1", false);
                    anim.SetBool("State2", true);
                    if (state2)
                    {
                        rightState = true;
                    }
                    else
                    {
                        rightState = false;
                    }



                }
                else if(anim.GetBool("State2") == true)
                {
                    Debug.Log("state3 true");
                    anim.SetBool("State2", false);
                    anim.SetBool("State3", true);

                    if (state3)
                    {
                        rightState = true;
                    }
                    else
                    {
                        rightState = false;
                    }
                }
                else if(anim.GetBool("State3") == true)
                {
                    Debug.Log("state1 true");
                    anim.SetBool("State3", false);
                    anim.SetBool("State1", true);
                    if (state1)
                    {
                        rightState = true;
                    }
                    else
                    {
                        rightState = false;
                    }

                }

                rotationState.checkRightState();

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            insideTrigger = false;
        }
    }
}
