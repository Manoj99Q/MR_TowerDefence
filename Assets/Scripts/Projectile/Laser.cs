using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public LineRenderer linerenderer;
    //enemy gameobject transform



    private float orglinemultiplier;

 
    private void Awake()
    {
        orglinemultiplier = linerenderer.widthMultiplier;
    }
    void Update()
    {
   

        
    }


    public void FireLaser(Transform _target,Transform Firepoint, int damagepersecond)
    {
        linerenderer.widthMultiplier = orglinemultiplier * GameSettings.GetScaleMultiplier();
        linerenderer.enabled = true;
        linerenderer.SetPosition(0, Firepoint.position);
        linerenderer.SetPosition(1, _target.position);
         

        _target.GetComponent<Health>().TakeDamage(damagepersecond*Time.deltaTime);

        

    }

    public void DisableLaser()
    {
        linerenderer.enabled = false;
    }



}
