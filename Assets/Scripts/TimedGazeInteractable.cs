using UnityEngine;
using UnityEngine.Events;

public class TimedGazeInteractable : GazeInteractable
{
    [SerializeField]
    private float gazeTriggerDuration;// Duration in seconds to trigger action
    private float gazeTimer = 0.0f; // Timer to track gaze duration

    [SerializeField]
    public UnityEvent OnGazeTrigger; // New event for timed trigger action

    new void Update()
    {
        base.Update(); // Call base class Update to handle basic hover logic

        if (IsHovered)
        {
            gazeTimer += Time.deltaTime;

            // Check if the gaze duration exceeds the threshold
            if (gazeTimer >= gazeTriggerDuration)
            {
                OnGazeTrigger?.Invoke(); // Trigger the timed action
                gazeTimer = 0.0f; // Reset the timer to prevent repeated triggers
            }
        }
        else
        {
            gazeTimer = 0.0f; // Reset timer when not hovering
        }
    }
}
