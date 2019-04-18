using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStatemachine : MonoBehaviour
{
    [SerializeField] private PlayerState[] states;

    private Dictionary<Type, PlayerState> stateDictionary = new Dictionary<Type, PlayerState>();
    private PlayerState currentState;
    private PlayerState baseS;

    protected virtual void Awake()
    {
        foreach (PlayerState state in states)
        {
            PlayerState instance = Instantiate(state);
            instance.Initialize(this);
            stateDictionary.Add(instance.GetType(), instance);
            if (currentState == null)
                currentState = instance;
            
        }
        currentState.Enter();
    }

    public void Transition<T>() where T : PlayerState
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
