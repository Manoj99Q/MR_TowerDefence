using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject UpgradeButtonPrefab;
    [SerializeField] private GameObject Content;

    private TowerStateManager currentfocusedTower;
    private void Awake()
    {
       
    }
    public void Initialize(TowerStateManager towerStateManager)
    {
        currentfocusedTower = towerStateManager;
        SetPosition();
        DisplayUpgradeOptions();
    }


    private void DisplayUpgradeOptions()
    {
        foreach (var upgrade in currentfocusedTower.Upgrades)
        {
            if (currentfocusedTower.IsApplied(upgrade))
            {
                continue;
            }

            UpgradeButton upgradeButton = Instantiate(UpgradeButtonPrefab, Content.transform).GetComponent<UpgradeButton>();
            upgradeButton.text.text = upgrade.upgradeName;
            upgradeButton.button.onClick.AddListener(() =>
            {
                upgrade.ApplyUpgrade(currentfocusedTower);
                currentfocusedTower.AddtoApplied(upgrade);
                DeleteAllChildren(Content);
                DisplayUpgradeOptions();
            });

        }
    }

    // Method to delete all child objects of the specified parent
    public void DeleteAllChildren(GameObject parent)
    {
        // Loop through all child objects and destroy them
        for (int i = parent.transform.childCount - 1; i >= 0; i--)
        {
            // Get the child at the current index
            Transform child = parent.transform.GetChild(i);

            // Destroy the child object
            Destroy(child.gameObject);
        }
    }


    private void SetPosition()
    {

        Vector3 spawnPosition = new Vector3(currentfocusedTower.transform.position.x, Camera.main.transform.position.y, currentfocusedTower.transform.position.z); ;

        transform.position = spawnPosition;
        // Get the camera's forward direction without the Y component
        Vector3 cameraForwardNoY = Camera.main.transform.forward;
        cameraForwardNoY.y = 0f;
        cameraForwardNoY = cameraForwardNoY.normalized;

        // Rotate the object to look at the camera while preserving its Z-axis rotation
        transform.rotation = Quaternion.LookRotation(cameraForwardNoY, Vector3.up);
    }
   public void CloseMenu()
    {
        Destroy(this.gameObject);
    }
}
