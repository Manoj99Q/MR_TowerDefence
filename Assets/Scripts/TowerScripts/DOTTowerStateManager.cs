using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  DOTTowerStateManager : TowerStateManager
{
    protected override void Awake()
    {
        base.Awake();
        SeekAndAttackState = new DamageOverTimeState();
    }


    public abstract void StartDealDamageOverTime();
    public abstract void StopDealDamageOverTime();
    public abstract void UpdateDealDamageOverTime();

}
