using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DistanceGrabInteractable;
    public GameObject ScaleCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ConfirmScale()
    {
        Debug.Log("pressed confirm");
        DistanceGrabInteractable.SetActive(false);
        ScaleCanvas.SetActive(false);
    }
}
