using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;

    private Transform Target;

    private int wayPointIndex = 0;

    [Tooltip("time duration for turning at waypoinmts")]
    public float Timetorotate;


    private void Awake()
    {
        //Scaling Adjustment
        movementSpeed *= GameSettings.GetScaleMultiplier();
        transform.localScale  *= GameSettings.GetScaleMultiplier();
        Target = WayPoints.waypoints[0];
    }

    private void Update()
    {
        //considering the vertial offset
        Vector3 AdjustedTraget = Target.position + GetComponent<EnemyData>().GetOffset();
        Vector3 dir = AdjustedTraget - transform.position;
        transform.Translate(movementSpeed * Time.deltaTime * dir.normalized,Space.World);
    

        if (Vector3.Distance(transform.position, AdjustedTraget) < (0.2f* GameSettings.GetScaleMultiplier()))
        {
            GetNextWayPoint();


        }
        //Enemy Reached EndPoint
        if(Vector3.Distance(transform.position, WayPoints.EndPoint.position+ GetComponent<EnemyData>().GetOffset()) < (0.2f*GameSettings.GetScaleMultiplier()))
        {
            ReachedEnd();
            Destroy(gameObject);
        }
    }

    public void GetNextWayPoint()
    {
      
        wayPointIndex++;

        if (wayPointIndex == WayPoints.waypoints.Count)
        {
            Target = WayPoints.EndPoint;
            //transform.LookAt(Target.position);
            transform.DOLookAt(Target.position,Timetorotate);
            return;
        }
        if (wayPointIndex < WayPoints.waypoints.Count)
        {
            Target = WayPoints.waypoints[wayPointIndex];
            // transform.LookAt(Target.position);
            transform.DOLookAt(Target.position, Timetorotate);
        }
       
    }


    public void ReachedEnd()
    {
        Lives.LoseLife();
    }
}
