using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private LineRenderer linerenderer;
    private Transform _target;
    private Transform _FirePoint;
    private float _damagePerSecond;



    private float orglinemultiplier;

 
    private void Awake()
    {
        linerenderer = GetComponent<LineRenderer>();
        orglinemultiplier = linerenderer.widthMultiplier;
        
    }
    void Update()
    {
   

        if(_target != null)
        {
            FireLaser();
        }
        else
        {
           DisableLaser();
        }
    }

    public void Initialize(Transform target,float damagePersecond,Transform FirePoint)
    {
        _target = target;
        _FirePoint = FirePoint;
        _damagePerSecond = damagePersecond;
    }
    public void FireLaser()
    {
        linerenderer.widthMultiplier = orglinemultiplier * GameSettings.GetScaleMultiplier();
        linerenderer.SetPosition(0, _FirePoint.position);
        linerenderer.SetPosition(1, _target.position);
         

        _target.GetComponent<Health>().TakeDamage(_damagePerSecond*Time.deltaTime);

        

    }

    public void DisableLaser()
    {
        Destroy(this.gameObject);
    }



}
