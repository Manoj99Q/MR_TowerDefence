using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kills : MonoBehaviour
{
    private static int EnemyKills;
    private void Awake()
    {
        EnemyKills = 0;

        Health.EnemyKilled += (int currnecy) =>
        {
            IncrementKillCount(1);
        };

        GameStatsUI.Kills.text = EnemyKills.ToString();
    }

    public static void IncrementKillCount( int num)
    {
        EnemyKills += num;
        GameStatsUI.Kills.text = EnemyKills.ToString();
    }


}
