using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private UpgradeMenuManager UpgradeMenu;
    private UpgradeMenuManager currentMenu;
    private TowerStateManager currentlyfocused;
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
                if (currentlyfocused==towerState)
                {
                    return;
                }
                else
                {
                    Destroy(currentMenu.gameObject);
                }
            }

            currentlyfocused = towerState;
            currentMenu = Instantiate(UpgradeMenu);
            currentMenu.Initialize(towerState);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
