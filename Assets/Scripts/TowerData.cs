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
        /*if(towerType == TowerType.Basic)
        {
            TryGetComponent(out PlacementChecker checker);
            checker.potentialTowerPrefab = GameSettings.ValidBasicTower;
            checker.InvalidTowerPrefab = GameSettings.InValidBasicTower;
        }
        else
        {
            TryGetComponent(out PlacementChecker checker);
        }*/


        transform.localScale *= GameSettings.GetScaleMultiplier();
    }

   
}
