using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public int WaveNumber;
    public int EnemyPos;
    [Tooltip("Bottom Point Transform of the Prefab")]
    public Transform Base;

    public int CurrencyafterDeath;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    //Vertical offset for proper placement
    public Vector3 GetOffset()
    {
        return new Vector3(0f,transform.position.y - Base.position.y,0f);
    }
}
