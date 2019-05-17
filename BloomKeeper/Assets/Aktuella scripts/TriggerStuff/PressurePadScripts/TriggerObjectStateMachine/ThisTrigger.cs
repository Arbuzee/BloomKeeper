using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisTrigger : TriggerObjectStateMachine
{

    [SerializeField] public LayerMask TriggerLayerMask;
    [HideInInspector] public BoxCollider boxCollider;
    [SerializeField] public GameObject [] AnimObject;
    [SerializeField] public ThisTrigger LockObject;
    [HideInInspector] public bool isActive = false;

    protected override void Awake()
    {
        base.Awake();
        boxCollider = GetComponent<BoxCollider>();
    }
}
