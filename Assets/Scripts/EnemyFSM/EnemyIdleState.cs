using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateManager esm) : base(EnemyState.Idle,esm) { }

    public override void EnterState()
    {
        Debug.Log("Entered Idle State");

        // Immediately transition to walking state  
        stateManager.TransitionToState(EnemyState.Walking);
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Idle State");
    }

    public override void UpdateState() { }



    public override void OnTriggerEnter(Collider other) { }
    public override void OnTriggerStay(Collider other) { }
    public override void OnTriggerExit(Collider other) { }
}
