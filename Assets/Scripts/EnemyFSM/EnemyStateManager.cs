using UnityEngine;
public enum EnemyState
{
    Idle,
    Walking
}
public class EnemyStateManager : StateManager<EnemyState>
{


 

    protected  void Awake()
    {
    

        States.Add(EnemyState.Idle, new EnemyIdleState(this));
        States.Add(EnemyState.Walking, new EnemyWalkingState(this));

        CurrentState = States[EnemyState.Idle]; // Start in the Idle state
    }

    public void StartWalking()
    {
        // Implement logic to start walking
    }

    public void StopWalking()
    {
        // Implement logic to stop walking
    }

    public void MoveToNextWaypoint()
    {
        // Implement logic to move to the next waypoint
    }
}
