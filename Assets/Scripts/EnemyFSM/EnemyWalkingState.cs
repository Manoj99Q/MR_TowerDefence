using UnityEngine;

public class EnemyWalkingState : EnemyBaseState
{
  
    public EnemyWalkingState(EnemyStateManager esm) : base(EnemyState.Walking,esm) { }

    public override void EnterState()
    {
        Debug.Log("Entered Walking State");
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Walking State");
    }

    public override void UpdateState()
    {

        Debug.Log("In Walking State");
        enemyStateManager.MoveToNextWaypoint();
    }




}
