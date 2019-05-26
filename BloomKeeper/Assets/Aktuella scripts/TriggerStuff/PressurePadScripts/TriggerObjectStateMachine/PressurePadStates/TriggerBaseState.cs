using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Triggers/TriggerBaseState")]
public class TriggerBaseState : TriggerStatusState
{
    protected Collider[] colliders = new Collider[2];
    protected ThisTrigger owner;



    protected bool isInLeverRange = false;     //LeverBool


    public override void Enter()
    {
        Debug.Log("TriggerBaseState -> enter ");
        
    }


    public override void Exit()
    {
        Debug.Log("TriggerBaseState -> Exit");
    }

    public override void Initialize(TriggerObjectStateMachine owner)
    {
        this.owner = (ThisTrigger)owner;
    }

    protected Collider[] boxOverlap()
    {
        colliders = Physics.OverlapBox(owner.transform.position, owner.boxCollider.size / 2, Quaternion.identity, owner.TriggerLayerMask);
        //Debug.Log(colliders[0] + " " + colliders[1]);
        return colliders;
        
        
            
    }



    protected bool BoxCheck()
    {
        if(Physics.CheckBox(owner.transform.position, owner.boxCollider.size / 2, Quaternion.identity, owner.TriggerLayerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool PlayerDecoyColliding()
    {
        boxOverlap();
        if(colliders.Length < 1)
        {
            //Debug.Log(colliders[1].name);

            Debug.Log(colliders.Length.ToString());
            return false;
        }
        else
        {
            Debug.Log(colliders.Length.ToString());
            //Debug.Log(colliders[0].name);
            return true;
        }
    }

    protected void ActivateCable()
    {
        foreach (GameObject cabel in owner.cabels)
        {
            cabel.GetComponent<Renderer>().material = owner.ActivatedMaterial;
            cabel.GetComponentInChildren<ParticleSystem>().Play();
        }
    }
    protected void DeActivateCabel()
    {
        foreach (GameObject cabel in owner.cabels)
        {
            cabel.GetComponent<Renderer>().material = owner.DeActivatedMaterial;
        }
    }


    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
    //        //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
    //        Gizmos.DrawWireCube(owner.transform.position, owner.boxCollider.size);
    //}

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;

    //    //Check if there has been a hit yet

    //    if (hitBool)
    //    {
    //        //Draw a Ray forward from GameObject toward the hit
    //        Gizmos.DrawRay(owner.transform.position, owner.transform.forward * hit.distance);
    //        //Draw a cube that extends to where the hit exists
    //        Gizmos.DrawWireCube(owner.transform.position + owner.transform.up * hit.distance, owner.transform.localScale);
    //    }
    //    //If there hasn't been a hit yet, draw the ray at the maximum distance
    //    else
    //    {
    //        //Draw a Ray forward from GameObject toward the maximum distance
    //        Gizmos.DrawRay(owner.transform.position, owner.transform.up * 1f);
    //        //Draw a cube at the maximum distance
    //        Gizmos.DrawWireCube(owner.transform.position + owner.transform.up * 1, owner.transform.localScale);
    //    }
    //}

}
