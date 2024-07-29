using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerStateManager : DOTTowerStateManager
{
    [Header("LaserTower")]
    [Tooltip("Laser prefab")]
    [SerializeField] private Laser laser;
    [SerializeField] private float DamagePerSecond;

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

    public override void UpdateDealDamageOverTime()
    {
        Debug.Log("Laser Tower Update Deal Damage Over Time");
        GetTarget();
        if (currlaseer == null)
        {
            currlaseer = Instantiate(laser, firePoint.position, Quaternion.identity);
            currlaseer.enabled = true;
            currlaseer.Initialize(target, DamagePerSecond, firePoint);
        }
        else
        {
           
            currlaseer.Initialize(target, DamagePerSecond, firePoint);
        }

    }
}
