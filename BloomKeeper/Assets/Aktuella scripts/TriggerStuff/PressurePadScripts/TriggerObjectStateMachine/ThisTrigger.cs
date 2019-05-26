using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisTrigger : TriggerObjectStateMachine
{
    [HideInInspector] public bool isActive = false;
    [HideInInspector] public BoxCollider boxCollider;

    [SerializeField] public LayerMask TriggerLayerMask;
    [SerializeField] public GameObject [] AnimObject;

    [Header("Object to lock")]
    [SerializeField] public ThisTrigger LockObject;

    protected override void Awake()
    {
        base.Awake();
        boxCollider = GetComponent<BoxCollider>();
    }
}
