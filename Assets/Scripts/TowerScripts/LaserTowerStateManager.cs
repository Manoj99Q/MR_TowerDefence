using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerStateManager : DOTTowerStateManager
{
    [Header("LaserTower")]
    [Tooltip("Laser prefab")]
    [SerializeField] private Laser laser;
    public float DamagePerSecond;

    private Laser currlaseer;

    public override void StartDealDamageOverTime()
    {
        Debug.Log("Laser Tower Start Deal Damage Over Time");
       
    }

    public override void StopDealDamageOverTime()
    {
        Debug.Log("Laser Tower Stop Deal Damage Over Time");
        if(currlaseer != null)
        {
            Destroy(currlaseer.gameObject);
            currlaseer = null;
        }
        
    }
    //gets called only if the enemey is in range 
    public override void UpdateDealDamageOverTime()
    {
        Debug.Log("Laser Tower Update Deal Damage Over Time");
        GetTarget();

        if (target == null)
        {
            Debug.Log("No target found.");
            return;
        }
        Debug.Log("Target found.");
        if (currlaseer == null)
        {
            // Instantiate a new laser object
            currlaseer = Instantiate(laser, firePoint.position, Quaternion.identity);
        }

        // Update the laser
        currlaseer.FireLaser(firePoint.position, target.position, DamagePerSecond);

    }

    public void UpgradeLaser(Laser _laser)
    {
        this.laser = _laser;
        if(currlaseer != null)
        {
            currlaseer.DisableLaser();
            currlaseer = null;
        }

    }
}
