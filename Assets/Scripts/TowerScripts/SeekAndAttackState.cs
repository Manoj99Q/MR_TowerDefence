using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAndAttackState : TowerBaseState
{
    public override void EnterState(TowerStateManager towerStateManager)
    {

    }

    public override void ExitState(TowerStateManager towerStateManager)
    {

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

        towerStateManager.GetTarget();
        towerStateManager.LockToTarget();

        towerStateManager.Fire();

    }
}
