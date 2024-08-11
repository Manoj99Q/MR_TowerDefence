using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : BaseState<EnemyState>
{

    protected EnemyStateManager enemyStateManager;
    // Constructor that directly accepts an EnemyStateManager
    public EnemyBaseState(EnemyState key, EnemyStateManager _enemyStateManager)
        : base(key, _enemyStateManager)
    {
        enemyStateManager = _enemyStateManager;
    }

}
