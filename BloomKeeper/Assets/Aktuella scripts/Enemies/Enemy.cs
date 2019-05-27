using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : EnemyStatemachine
{
    [HideInInspector] public MeshRenderer Renderer;
    [HideInInspector] public NavMeshAgent agent;
    [SerializeField] public LayerMask visionMask;
    [SerializeField] public CapsuleCollider capCollider;
    //[SerializeField] public BoxCollider boxCollider;
    [SerializeField] public PlayerStateOwner player;
    //[SerializeField] public GameObject decoy;
    [SerializeField] public int Dmg = 1;
    [SerializeField] public bool prone = false;
    [SerializeField] public Transform Mouth;
    [SerializeField] public BoxCollider AttackCollider;

    protected override void Awake()
    {



        //Renderer = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        base.Awake();
        Debug.Log("Enemy.cs" + currentState.ToString());


    }


}
