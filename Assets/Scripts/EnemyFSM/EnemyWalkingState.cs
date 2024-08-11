using UnityEngine;

public class EnemyWalkingState : BaseState<EnemyState>
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
       

        MoveToNextWaypoint();
    }



    public override void OnTriggerEnter(Collider other) { }
    public override void OnTriggerStay(Collider other) { }
    public override void OnTriggerExit(Collider other) { }

    private void MoveToNextWaypoint()
    {
        Debug.Log("Moving to next waypoint");
    }
}
