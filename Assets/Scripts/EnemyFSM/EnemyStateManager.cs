using System.Collections.Generic;
using UnityEngine;
public enum EnemyState
{
    Idle,
    Walking
}
public class EnemyStateManager : StateManager<EnemyState>
{

    public List<Transform> WayPoints;
    [HideInInspector] public Transform Endpoint;
    private Rigidbody Rigidbody;
    public Transform TargetWaypoint;
    private int CurrentWaypointIndex = 0;
    [SerializeField] private float Speed; // Movement speed


    protected void Awake()
    {

        Rigidbody = GetComponent<Rigidbody>();
       

        States.Add(EnemyState.Idle, new EnemyIdleState(this));
        States.Add(EnemyState.Walking, new EnemyWalkingState(this));

        CurrentState = States[EnemyState.Idle]; // Start in the Idle state


    }



    public void MoveToNextWaypoint()
    {

        if (Rigidbody == null || WayPoints == null || WayPoints.Count == 0)
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

            direction = (Endpoint.position - Rigidbody.position);
            direction.y = 0; // Ignore the Y component

            distance = Vector3.Distance(new Vector3(Rigidbody.position.x, 0, Rigidbody.position.z), new Vector3(Endpoint.position.x, 0, Endpoint.position.z));

            // Destroy the enemy when it reaches the Endpoint
            if (distance < 0.1f)
            {
                Debug.Log("Reached Endpoint. Destroying enemy.");
                Destroy(gameObject);
                return;
            }
        }
        else
        {
            // Move towards the current waypoint
            direction = (TargetWaypoint.position - Rigidbody.position);
            direction.y = 0; // Ignore the Y component

            distance = Vector3.Distance(new Vector3(Rigidbody.position.x, 0, Rigidbody.position.z), new Vector3(TargetWaypoint.position.x, 0, TargetWaypoint.position.z));

            // Update to the next waypoint if close enough
            if (distance < 0.1f)
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
                }
            }
        }

        // Normalize the direction vector
        direction.Normalize();

        // Apply force for movement
        Rigidbody.AddForce(direction * Speed, ForceMode.Force);


        Debug.Log($"Direction: {direction}, Distance: {distance}");
    }

}
