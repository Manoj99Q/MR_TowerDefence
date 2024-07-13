using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public int InitialLives;

    private static int CurrentLives;

    public int Display;

    private void Awake()
    {
        CurrentLives = InitialLives;
        GameStatsUI.Lives.text = CurrentLives.ToString();
    }

   


    public static void LoseLife()
    {
        CurrentLives--;
        GameStatsUI.Lives.text = CurrentLives.ToString();

    }


}
