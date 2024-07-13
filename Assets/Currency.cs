using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private static int CurrentCurrency;

    public int display;

    private void Awake()
    {
        CurrentCurrency = 2000; // initial Currency
        Health.EnemyKilled += EnemyKilledHandler;
        GameStatsUI.Currency.text = CurrentCurrency.ToString();
    }

    private void Update()
    {
        display = CurrentCurrency;
    }
    

    public static void AddCurrency(int currency)
    {
        CurrentCurrency += currency;
        GameStatsUI.Currency.text = CurrentCurrency.ToString();
    }


    public static void RemoveCurrency(int currency)
    {
        CurrentCurrency -= currency;
        GameStatsUI.Currency.text = CurrentCurrency.ToString();
    }

    public static bool Contains(int currency)
    {
        return CurrentCurrency >= currency;
    }

    void EnemyKilledHandler(int currency)
    {
        AddCurrency(currency);
        GameStatsUI.Currency.text = CurrentCurrency.ToString();
    }
}
