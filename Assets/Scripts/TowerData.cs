using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour
{
    public Transform BottomPoint;
    public int TowerPrice;

    // Update is called once per frame
    private void Awake()
    {
       


        transform.localScale *= GameSettings.GetScaleMultiplier();
    }

   
}
