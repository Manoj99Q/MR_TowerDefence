using System.Collections.Generic;
using UnityEngine;

public class GazeTrackingRay : MonoBehaviour
{
    private float rayDistance = 10.0f; // Adjust the distance as needed
    [SerializeField]
    private LayerMask layersToInclude;

    private List<GazeInteractable> gazeInteractables;

    private GazeInteractable currentGazeInteractable = null;

    void Start()
    {
        gazeInteractables = new List<GazeInteractable>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 rayCastDirection = transform.forward;

        // Cast a ray forward from the camera
        if (Physics.Raycast(transform.position, rayCastDirection, out hit, rayDistance, layersToInclude))
        {
            Debug.Log("Raycast Hit: " + hit.transform.name);

            if (hit.transform.TryGetComponent(out GazeInteractable gazeInteractable))
            {
                // If a new object is gazed at, trigger OnGazeEnter
                if (currentGazeInteractable != gazeInteractable)
                {
                    UnSelect();
                    currentGazeInteractable = gazeInteractable;
                    currentGazeInteractable.IsHovered = true;
                    currentGazeInteractable.OnGazeEnter.Invoke(hit.transform.gameObject);
                }

                // Trigger OnGazeStay while still gazing at the object
                currentGazeInteractable.OnGazeStay.Invoke(hit.transform.gameObject);
            }
        }
        else
        {
            UnSelect();
        }
    }

    void UnSelect()
    {
        if (currentGazeInteractable != null)
        {
            // Trigger OnGazeExit when the object is no longer gazed at
            currentGazeInteractable.OnGazeExit.Invoke(currentGazeInteractable.gameObject);
            currentGazeInteractable.IsHovered = false;
            currentGazeInteractable = null;
        }
    }
}
