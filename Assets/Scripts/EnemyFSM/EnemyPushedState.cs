using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPushedState : EnemyBaseState
{
    public EnemyPushedState(EnemyStateManager esm) : base(EnemyState.Pushed,esm) { }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Entered Pushed State");
    }



    public override void OnColliderEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & enemyStateManager.groundedLayer) != 0)
        {
            enemyStateManager.TransitionToState(EnemyState.Walking);
        }
    }

    public override void UpdateState()
    {
      

        Debug.Log("In Pushed State");
  

    }
}
