using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisTrigger : TriggerObjectStateMachine
{
    public BoxCollider boxCollider;
    public LayerMask TriggerLayerMask;
    public GameObject AnimObject;

    protected override void Awake()
    {
        base.Awake();
    }
}
