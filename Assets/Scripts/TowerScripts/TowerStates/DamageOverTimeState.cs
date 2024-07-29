using System.Collections;
using UnityEngine;

public class DamageOverTimeState : SeekAndAttackState
{
 

    public override void EnterState(TowerStateManager towerStateManager)
    {
        base.EnterState(towerStateManager);
        // Start dealing damage over time when entering this state
        DOTTowerStateManager dOtTowerStateManager = (DOTTowerStateManager)towerStateManager;
        dOtTowerStateManager.StartDealDamageOverTime(); 
    }

    public override void ExitState(TowerStateManager towerStateManager)
    {
        base.ExitState(towerStateManager);
        ((DOTTowerStateManager)towerStateManager).StopDealDamageOverTime();
    }
    

    public override void UpdateState(TowerStateManager towerStateManager)
    {
        if (!towerStateManager.EnemyInRange())
        {
            towerStateManager.TransitionToState(towerStateManager.IdleState);
            return;
        }

        if (towerStateManager.IsGrabbed)
        {
            towerStateManager.TransitionToState(towerStateManager.GrabbedState);
            return;
        }

        ((DOTTowerStateManager)towerStateManager).UpdateDealDamageOverTime();
    }

   
}
