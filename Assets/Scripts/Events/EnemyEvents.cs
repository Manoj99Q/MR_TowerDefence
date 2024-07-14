using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvents
{

    public static event Action<Health,float> EnemyDamaged; // Health component of the enemy and the damage enemy has taken

    public static void RaiseEnenmyDamagedEvent(Health enemyhealthcomp,float damageTaken)
    {
        EnemyDamaged?.Invoke(enemyhealthcomp, damageTaken);
    }


    public static event Action<EnemyData> EnemyKilled;

    public static void RaiseEnemyKilledEvent(EnemyData enemyData) {
        EnemyKilled?.Invoke(enemyData);
    }

}
