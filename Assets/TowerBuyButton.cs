using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuyButton : MonoBehaviour
{
    public GameObject TowerPrefab;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyTower()
    {
        int towerPrice = TowerPrefab.GetComponent<TowerData>().TowerPrice;
        //check if our currency has the enough money
      /*  if (Currency.Contains(towerPrice))
        {
            SpawnTower();
            Currency.RemoveCurrency(towerPrice);
        }*/
    }
     private void SpawnTower()
    {
        //spawn in front of the menu
        Instantiate(TowerPrefab, transform.position - transform.forward * 0.1f, Quaternion.identity);
    }
}
