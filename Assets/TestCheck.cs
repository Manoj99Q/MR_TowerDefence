using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCheck : MonoBehaviour
{
    public GameObject TowerPrefab;
    public GameObject BombTower;
    public GameObject LaserTower;
    public OVRHand rightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnTower(TowerPrefab);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SpawnTower(BombTower);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnTower(LaserTower);
        }
    }

    private void SpawnTower( GameObject tower)
    {

        
        //spawn in center of Basedplane test
        Instantiate(tower, GameSettings.basePlane.transform).transform.position = rightHand.transform.position;
    }
}
