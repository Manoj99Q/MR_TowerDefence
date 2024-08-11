    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ShopManager : MonoBehaviour
    {
        [Tooltip("Distance in front of the camera the menu should spawn")]
        public float spawnDistance;

        [SerializeField]
        private GameObject BasicTower;
        [SerializeField]
        private GameObject BombTower;
        [SerializeField]
        private GameObject LaserTower;
        


        private void OnEnable()
        {
            Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * spawnDistance;

            transform.position = spawnPosition;


            // Get the camera's forward direction without the Y component
            Vector3 cameraForwardNoY = Camera.main.transform.forward;
            cameraForwardNoY.y = 0f;
            cameraForwardNoY = cameraForwardNoY.normalized;

            // Rotate the object to look at the camera while preserving its Z-axis rotation
            transform.rotation = Quaternion.LookRotation(cameraForwardNoY, Vector3.up);
        }

        public void ToggleShop()
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)){
            ToggleShop();
        }
    }


    public void BuyTower(TowerType towertype)
        {

        GameObject towerToSpawn = null;

        // Determine which tower to spawn based on the TowerType enum
        switch (towertype)
        {
            case TowerType.BasicTower:
                towerToSpawn = BasicTower;
                break;
            case TowerType.BombTower:
                towerToSpawn = BombTower;
                break;
            case TowerType.LaserTower:
                towerToSpawn = LaserTower;
                break;
            default:
                Debug.LogError("Unhandled TowerType!");
                return;
        }

        

        // Spawn the selected tower
        if (towerToSpawn != null)
        {
            SpawnTower(towerToSpawn);
        }
        else
        {
            Debug.LogError("Tower prefab is not assigned!");
        }

    }
    public void BuyTowerusingPrefab(GameObject towerprefab)
    {
        SpawnTower(towerprefab);
    }

    private void SpawnTower(GameObject tower)
        {
        //spawn in fron of the shop
        Instantiate(tower, GameSettings.BasePlane.transform).transform.position = transform.position - (0.1f * transform.forward );
        }
    }
