using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        float left_right = Input.GetAxis("Horizontal");
        float bwd_fwd = Input.GetAxis("Vertical");

        anim.SetFloat("left_right", left_right);
        anim.SetFloat("bwd_fwd", bwd_fwd);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("decoy");
        }
    }

    public void StandOnPad()
    {
        anim.SetTrigger("pressurepad");
    }
}
