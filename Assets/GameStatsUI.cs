using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatsUI : MonoBehaviour
{
    public TextMeshProUGUI _Currency;
    public TextMeshProUGUI _Lives;
    public TextMeshProUGUI _Kills;


    public static TextMeshProUGUI Currency;
    public static TextMeshProUGUI Lives;
    public static TextMeshProUGUI Kills;


    private void Awake()
    {
        Currency = _Currency;
        Lives = _Lives;
        Kills = _Kills;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
