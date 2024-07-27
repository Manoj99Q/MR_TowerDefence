using UnityEngine;
using UnityEngine.Events;

public class GazeInteractable : MonoBehaviour
{
    public bool IsHovered { get; set; }

    [SerializeField]
    public UnityEvent<GameObject> OnGazeEnter;

    [SerializeField]
    public UnityEvent<GameObject> OnGazeStay;

    [SerializeField]
    public UnityEvent<GameObject> OnGazeExit;

    void Start()
    {
        IsHovered = false;
    }

    void Update()
    {
        if (IsHovered)
        {
            Debug.Log("Hovering over: " + gameObject.name);
        }
    }
}
