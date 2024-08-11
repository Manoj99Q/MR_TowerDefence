using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public  List<Transform> waypointsList;
    public  Transform StartPoint;
    public  Transform EndPoint;


    private void Awake()
    {

        waypointsList = new List<Transform>();

        foreach(Transform child in transform)
        {
            waypointsList.Add(child);
        }
    }


    



}
