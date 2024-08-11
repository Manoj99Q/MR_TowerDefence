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

    public abstract void OnColliderEnter(Collision collision);
    public override void EnterState()
    {
       enemyStateManager.anim.SetBool(StateKey.ToString(), true);
    }

    public override void ExitState()
    {
        enemyStateManager.anim.SetBool(StateKey.ToString(), false);
    }

}
