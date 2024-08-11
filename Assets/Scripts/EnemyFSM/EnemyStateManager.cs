using System.Collections.Generic;
using UnityEngine;
public enum EnemyState
{
    Idle,
    Pushed,
    Walking,
    Rotating
}
public class EnemyStateManager : StateManager<EnemyState>
{

    public List<Transform> WayPoints;
    [HideInInspector] public Transform Endpoint;
    [HideInInspector] public Rigidbody rigidbody;
    public Transform TargetWaypoint;
    private int CurrentWaypointIndex = 0;
    [SerializeField] private float Speed; // Movement speed

    private CapsuleCollider _capsuleCollider; // Reference to the enemy's capsule collider
    public LayerMask groundedLayer;
    public Animator anim;

    protected void Awake()
    {

        rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>(); // Get the capsule collider component

        States.Add(EnemyState.Idle, new EnemyIdleState(this));
        States.Add(EnemyState.Walking, new EnemyWalkingState(this));
        States.Add(EnemyState.Rotating, new EnemyRotatingState(this));
        States.Add(EnemyState.Pushed, new EnemyPushedState(this));

        CurrentState = States[EnemyState.Idle]; // Start in the Idle state


    }



    public void MoveToNextWaypoint()
    {

        if (rigidbody == null || WayPoints == null || WayPoints.Count == 0)
        {
            Debug.Log("Invalid setup.");
            return;
        }

        Vector3 direction;
        float distance;

        // If at the last waypoint, move towards the Endpoint
        if (CurrentWaypointIndex >= WayPoints.Count)
        {
            if (Endpoint == null)
            {
                Debug.LogError("Endpoint not assigned.");
                return;
            }

            direction = (Endpoint.position - rigidbody.position);
            direction.y = 0; // Ignore the Y component

            distance = Vector3.Distance(new Vector3(rigidbody.position.x, 0, rigidbody.position.z), new Vector3(Endpoint.position.x, 0, Endpoint.position.z));

            // Destroy the enemy when it reaches the Endpoint
            if (distance < (0.1f * GameSettings.GetScaleMultiplier()))
            {
                Debug.Log("Reached Endpoint. Destroying enemy.");
                Destroy(gameObject);
                return;
            }
        }
        else
        {
            // Move towards the current waypoint
            direction = (TargetWaypoint.position - rigidbody.position);
            direction.y = 0; // Ignore the Y component

            distance = Vector3.Distance(new Vector3(rigidbody.position.x, 0, rigidbody.position.z), new Vector3(TargetWaypoint.position.x, 0, TargetWaypoint.position.z));

            // Update to the next waypoint if close enough
            if (distance < (0.1f * GameSettings.GetScaleMultiplier()))
            {
                Debug.Log("Within Range of Waypoint. Moving to next waypoint.");

                CurrentWaypointIndex++;
                if (CurrentWaypointIndex < WayPoints.Count)
                {
                    TargetWaypoint = WayPoints[CurrentWaypointIndex];
                }
                else
                {
                    // All waypoints visited, start heading towards Endpoint
                    TargetWaypoint = Endpoint;
                    Debug.Log("All waypoints visited. Heading towards Endpoint.");
                }

                // Transition to rotating state
                TransitionToState(EnemyState.Rotating);
            }
        }

        // Calculate desired velocity
        Vector3 desiredVelocity = direction.normalized * Speed;

        // Apply force to change the velocity
        rigidbody.AddForce(desiredVelocity, ForceMode.VelocityChange);

        Vector3 flatvel = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        
        if(flatvel.magnitude > Speed * GameSettings.GetScaleMultiplier())
        {
            rigidbody.velocity = flatvel.normalized * Speed * GameSettings.GetScaleMultiplier();
        }

    }

    public bool GroundCheck()
    {
        if (_capsuleCollider == null)
        {
            Debug.LogError("CapsuleCollider is missing on the enemy.");
            return false;
        }

        // Convert the local center of the capsule collider to world space
        Vector3 center = transform.TransformPoint(_capsuleCollider.center);
        float height = _capsuleCollider.bounds.extents.y;

        // Define an offset for better ground detection
        float offset = 0.1f * GameSettings.GetScaleMultiplier();

        // Perform a raycast from the center of the collider downwards
        RaycastHit hit;
        bool isGrounded = Physics.Raycast(center, Vector3.down, out hit, height + offset, groundedLayer);

        // Debug draw rays for visualization
        Debug.DrawRay(center, Vector3.down * (height + offset), Color.red);


        return isGrounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Call the OnColliderEnter method in the current state
        if (CurrentState is EnemyBaseState enemyBaseState)
        {
            enemyBaseState.OnColliderEnter(collision);
        }
    }


}

