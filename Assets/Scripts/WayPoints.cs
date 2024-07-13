using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static List<Transform> waypoints;
    public  Transform _StartPoint;
    public  Transform _EndPoint;
    public static Transform StartPoint;
    public static Transform EndPoint;

    private void Awake()
    {

        StartPoint = _StartPoint;
        EndPoint = _EndPoint;
        waypoints = new List<Transform>();

        foreach(Transform child in transform)
        {
            waypoints.Add(child);
        }
    }


    



}
