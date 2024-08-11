using UnityEngine;
public enum EnemyState
{
    Idle,
    Walking
}
public class EnemyStateManager : StateManager<EnemyState>
{


    public static EnemyStateManager Instance;

    protected  void Awake()
    {
        Instance = this;

        States.Add(EnemyState.Idle, new EnemyIdleState());
        States.Add(EnemyState.Walking, new EnemyWalkingState());

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
