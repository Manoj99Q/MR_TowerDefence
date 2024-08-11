using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : BaseState<EnemyState>
{


    // Constructor that directly accepts an EnemyStateManager
    public EnemyBaseState(EnemyState key, EnemyStateManager enemyStateManager)
        : base(key, enemyStateManager)
    {

    }

}
