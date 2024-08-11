using System;
using UnityEngine;

public abstract class BaseState<EState> where EState : Enum
{  
    public BaseState(EState key, StateManager<EState> _stateManager)
    {
        StateKey = key;

    }

    public EState StateKey { get; private set; }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();

}
