﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : ScriptableObject
{
    
    public virtual void Initialize(EnemyStatemachine owner) { }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void HandleUpdate() { }
}
