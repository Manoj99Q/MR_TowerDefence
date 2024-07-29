using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : TowerBaseState
{
    public override void EnterState(TowerStateManager towerStateManager)
    {
        Debug.LogWarning("In idle State");
        if(towerStateManager.TryGetComponent<Laser>(out Laser laser))
        {
            laser.DisableLaser();
        }
    }

    public override void ExitState(TowerStateManager towerStateManager)
    {

    }

    public override void UpdateState(TowerStateManager towerStateManager)
    {
        if (towerStateManager.IsGrabbed)
        {
            towerStateManager.TransitionToState(towerStateManager.GrabbedState);
            return;
        }

        if (towerStateManager.EnemyInRange())
        {
            towerStateManager.TransitionToState(towerStateManager.SeekAndAttackState);
        }


    }
}
