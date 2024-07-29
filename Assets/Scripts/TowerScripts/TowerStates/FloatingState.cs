using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In the air after spwaning or when released by the user
public class FloatingState : TowerBaseState
{
    public override void EnterState(TowerStateManager towerStateManager)
    {
        Debug.LogWarning("In Floating State");
        towerStateManager.Isplaced = false;
    }

    public override void ExitState(TowerStateManager towerStateManager)
    {
        
    }

    public override void UpdateState(TowerStateManager towerStateManager)
    {
        if (towerStateManager.IsGrabbed)
        {
            towerStateManager.TransitionToState(towerStateManager.GrabbedState);
        }


    }

}
