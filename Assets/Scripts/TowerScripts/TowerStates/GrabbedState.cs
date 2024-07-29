using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Grabbed by thye user
public class GrabbedState : TowerBaseState
// Start is called before the first frame update
{
    public override void EnterState(TowerStateManager towerStateManager)
    {
        Debug.LogWarning("Entered Grabbed State");
    }

    public override void ExitState(TowerStateManager towerStateManager)
    {

    }

    public override void UpdateState(TowerStateManager towerStateManager)

    {

        towerStateManager.CheckPlacement();
       

        if (!towerStateManager.IsGrabbed) // released by hand
        {
            towerStateManager.OnRelease();

            if (towerStateManager.Isplaced)
            {
                towerStateManager.TransitionToState(towerStateManager.IdleState);
            }
            else
            {
                towerStateManager.TransitionToState(towerStateManager.FloatingState);
            }
        }
    }
}
