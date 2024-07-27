using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum UpgradeMenuEventType
{
    Open,
    Close
}
public class Events 
{

 
    public static event Action<TowerStateManager,UpgradeMenuEventType> UpgradeMenuEvent;

    public static void RaiseUpgradeMenuEvent(TowerStateManager towerStateManager,UpgradeMenuEventType type)
    {
        UpgradeMenuEvent?.Invoke(towerStateManager, type);
    }
}
