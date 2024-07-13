using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBaseState
{
    public abstract void EnterState(TowerStateManager towerStateManager);

    public abstract void UpdateState(TowerStateManager towerStateManager);

    public abstract void ExitState(TowerStateManager towerStateManager);

}
