using UnityEngine;

public class EnemyWalkingState : BaseState<EnemyState>
{
    private Transform _enemyTransform;
    private Transform[] _waypoints;
    private int _currentWaypointIndex = 0;
    private float _speed;

    /*    public EnemyWalkingState(Transform enemyTransform, Transform[] waypoints, float speed) : base(EnemyState.Walking)
        {
            _enemyTransform = enemyTransform;
            _waypoints = waypoints;
            _speed = speed;
        }*/

    public EnemyWalkingState() : base(EnemyState.Idle) { }

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
        if (_waypoints.Length == 0)
        {
            Debug.LogError("No waypoints set for enemy walking state.");
            return;
        }

        MoveToNextWaypoint();
    }

    public override EnemyState GetNextState()
    {
        // Assuming walking is the default state and there's no condition to change from walking to another state
        return EnemyState.Walking;
    }

    public override void OnTriggerEnter(Collider other) { }
    public override void OnTriggerStay(Collider other) { }
    public override void OnTriggerExit(Collider other) { }

    private void MoveToNextWaypoint()
    {
        if (_currentWaypointIndex >= _waypoints.Length)
        {
            // Optionally, you could transition to another state here if needed
            return;
        }

        Transform targetWaypoint = _waypoints[_currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - _enemyTransform.position).normalized;
        _enemyTransform.position += direction * _speed * Time.deltaTime;

        // Check if the enemy is close enough to the waypoint to consider it reached
        if (Vector3.Distance(_enemyTransform.position, targetWaypoint.position) < 0.1f)
        {
            _currentWaypointIndex++;
        }
    }
}
