using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStatemachine : MonoBehaviour
{
    [SerializeField] private EnemyState[] states;

    private Dictionary<Type, EnemyState> stateDictionary = new Dictionary<Type, EnemyState>();
    protected EnemyState currentState;
    private EnemyState baseS;

    protected virtual void Awake()
    {
        Debug.Log("Awake/EnemyStateMachine");
        foreach (EnemyState state in states)
        {
            EnemyState instance = Instantiate(state);
            instance.Initialize(this);
            stateDictionary.Add(instance.GetType(), instance);
            if (currentState == null)
                currentState = instance;
        }
        currentState.Enter();
        Debug.Log("Awake/EnemyStateMachine");
    }

    public void Transition<T>() where T : EnemyState
    {
        currentState.Exit();
        currentState = stateDictionary[typeof(T)];
        currentState.Enter();
    }

    private void Update()
    {
        currentState.HandleUpdate();
    }



}
