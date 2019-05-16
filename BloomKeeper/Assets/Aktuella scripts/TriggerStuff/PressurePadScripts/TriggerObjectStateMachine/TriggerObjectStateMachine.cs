using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerObjectStateMachine : MonoBehaviour
{
    [SerializeField] private TriggerStatusState[] states;

    private Dictionary<Type, TriggerStatusState> stateDictionary = new Dictionary<Type, TriggerStatusState>();
    private TriggerStatusState currentState;

    protected virtual void Awake()
    {
        foreach (TriggerStatusState state in states)
        {
            TriggerStatusState instance = Instantiate(state);
            instance.Initialize(this);
            stateDictionary.Add(instance.GetType(), instance);
            if (currentState == null)
                currentState = instance;
        }
        currentState.Enter();
    }

    public void Transition<T>() where T : TriggerStatusState
    {
        currentState.Exit();
        currentState = stateDictionary[typeof(T)];
        currentState.Enter();
    }

    private void Update()
    {
        currentState.HandleUpdate();
    }

    private void FixedUpdate()
    {
        currentState.FixedHandelUpdate();
    }

}
