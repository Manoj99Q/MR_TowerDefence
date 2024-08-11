using UnityEngine;

public class EnemyIdleState : BaseState<EnemyState>
{
    public EnemyIdleState() : base(EnemyState.Idle) { }

    public override void EnterState()
    {
        Debug.Log("Entered Idle State");

        // Immediately transition to walking state
        EnemyStateManager.Instance.TransitionToState(EnemyState.Walking);
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Idle State");
    }

    public override void UpdateState() { }

    public override EnemyState GetNextState()
    {
        return EnemyState.Idle; // Stays in idle until manually transitioned
    }

    public override void OnTriggerEnter(Collider other) { }
    public override void OnTriggerStay(Collider other) { }
    public override void OnTriggerExit(Collider other) { }
}
