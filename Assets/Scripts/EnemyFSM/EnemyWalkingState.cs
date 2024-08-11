using UnityEngine;

public class EnemyWalkingState : EnemyBaseState
{
  
    public EnemyWalkingState(EnemyStateManager esm) : base(EnemyState.Walking,esm) { }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Entered Walking State");
    }

    public override void ExitState()
    {
        base.ExitState();
        enemyStateManager.rigidbody.velocity = Vector3.zero;    
    }

    public override void UpdateState()
    {
        if (!enemyStateManager.GroundCheck())
        {
            enemyStateManager.TransitionToState(EnemyState.Pushed);
        }

        Debug.Log("In Walking State");
        enemyStateManager.MoveToNextWaypoint();

    }

    public override void OnColliderEnter(Collision collision)
    {
        return;
    }




}
