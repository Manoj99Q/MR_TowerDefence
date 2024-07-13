using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 GameInitialScale;
    public static Vector3 CurrentGameScale;
  
    public static GameObject BasePlane;

    public static GameObject ValidBasicTower;
    public static GameObject InValidBasicTower;
    public static GameObject ValidBombTower;
    public static GameObject InValidBombTower;
    public static GameObject ValidLaserTower;
    public static GameObject InValidLaserTower;

    // Public variables with names starting with "_" for tower prefabs
    public GameObject _validBasicTower;
    public GameObject _inValidBasicTower;
    public GameObject _validBombTower;
    public GameObject _inValidBombTower;
    public GameObject _validLaserTower;
    public GameObject _inValidLaserTower;


    public static GameObject basePlane;



    [SerializeReference] private Slider ScaleSlider;

    public GameObject _baseplane;
    private void Awake()
    {
        BasePlane = GameObject.Find("BasePlane");
        GameInitialScale = BasePlane.transform.localScale;

        // Assign static variables using public variables with names starting with "_"
        ValidBasicTower = _validBasicTower;
        InValidBasicTower = _inValidBasicTower;
        ValidBombTower = _validBombTower;
        InValidBombTower = _inValidBombTower;
        ValidLaserTower = _validLaserTower;
        InValidLaserTower = _inValidLaserTower;

        basePlane = _baseplane;

    }
    // Update is called once per frame
    void Update()
    {

        BasePlane.transform.localScale = new Vector3(ScaleSlider.value, ScaleSlider.value, ScaleSlider.value);
        CurrentGameScale =  BasePlane.transform.localScale;
    }

    public static float GetScaleMultiplier()
    {
       


        return CurrentGameScale.x / GameInitialScale.x;
    }


}
