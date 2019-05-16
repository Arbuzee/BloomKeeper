using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStatusState : ScriptableObject
{
    public virtual void Initialize(TriggerObjectStateMachine owner) { }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void HandleUpdate() { }
    public virtual void FixedHandelUpdate() { }

}
