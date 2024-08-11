using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> CurrentState;



    void Start()
    {
        CurrentState.EnterState();
    }

    void Update()
    {
        CurrentState.UpdateState();
    }

    public void TransitionToState(EState stateKey)
    {

        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();

    }

    void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }

    void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }
}
