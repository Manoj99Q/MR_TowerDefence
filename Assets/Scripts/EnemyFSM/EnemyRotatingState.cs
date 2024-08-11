using UnityEngine;

public class EnemyRotatingState : EnemyBaseState
{
    private Quaternion _targetRotation;
    private float _rotationSpeed;

    public EnemyRotatingState(EnemyStateManager esm) : base(EnemyState.Rotating, esm)
    {
        _rotationSpeed = 5f; // Adjust this value to control rotation speed
    }

    public override void EnterState()
    {
        base.EnterState();  
        Debug.Log("Entered Rotating State");

        // Calculate the direction to the next waypoint
        Vector3 direction = (enemyStateManager.TargetWaypoint.position - enemyStateManager.rigidbody.position);
        direction.y = 0; // Ignore the Y component

        // Calculate the target rotation
        _targetRotation = Quaternion.LookRotation(direction);
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("Exiting Rotating State");

        // Ensure perfect alignment with the target direction
        enemyStateManager.transform.rotation = _targetRotation;
    }

    public override void UpdateState()
    {
        // Smoothly rotate towards the target rotation
        enemyStateManager.rigidbody.rotation = Quaternion.Slerp(
            enemyStateManager.rigidbody.rotation,
            _targetRotation,
            Time.deltaTime * _rotationSpeed
        );

        // Check if rotation is close enough to the target rotation
        if (Quaternion.Angle(enemyStateManager.rigidbody.rotation, _targetRotation) < 1f)
        {
            // Switch back to walking state
            enemyStateManager.TransitionToState(EnemyState.Walking);
        }
    }

    public override void OnColliderEnter(Collision collision)
    {
        return;
    }
}
