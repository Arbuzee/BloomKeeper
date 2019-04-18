using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : EnemyStatemachine
{
    [HideInInspector] public MeshRenderer Renderer;
    [HideInInspector] public NavMeshAgent agent;
    public LayerMask visionMask;
    public CapsuleCollider capCollider;
    public BoxCollider boxCollider;
    public Player player;
    public GameObject decoy;
    public int Dmg = 1;
    public bool prone = false;
    public Transform Mouth;

    protected override void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        base.Awake();
    }

    
}
