using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateManager esm) : base(EnemyState.Idle,esm) { }

    public override void EnterState()
    {
        Debug.Log("Entered Idle State");

        // Immediately transition to walking state  
        enemyStateManager.TransitionToState(EnemyState.Walking);
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Idle State");
    }

    public override void UpdateState() { }




}
