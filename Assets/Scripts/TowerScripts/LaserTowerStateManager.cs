using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerStateManager : TowerStateManager
{
    [Tooltip("Laser Only")]
    public Laser LaserLine;
    public override void Fire()
    {
        if(target != null)
        {
            FireLaser();
        }
                                                         
    }



    protected void FireLaser()
    {
        LaserLine.FireLaser(target, firePoint, Damage);
    }

    protected void DisableLaser()
    {
        LaserLine.DisableLaser();
    }


}
