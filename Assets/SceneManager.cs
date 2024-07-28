using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeMenu;
    private GameObject currentMenu;
    // Start is called before the first frame update
    void Start()
    {
        Events.UpgradeMenuEvent += Events_UpgradeMenuEvent;
    }

    private void Events_UpgradeMenuEvent(TowerStateManager towerState, UpgradeMenuEventType type)
    {
        if(type == UpgradeMenuEventType.Open)
        {

            if (currentMenu != null)
            {
                Destroy(currentMenu);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
