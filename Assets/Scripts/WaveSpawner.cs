using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int waveNumber = 0;
    public float timebetweenWaves = 3f;
    private float timer = 2f;
    void Update()
    {
        /*if (timer > 3f)
        {
           
            StartCoroutine(SpawnWave());
            timer = 0f;

        }

        timer += Time.deltaTime;*/
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(SpawnWave());
        }

    }

    public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }
     IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy(i+1);
            yield return new WaitForSeconds(0.5f);
        }
        
       
    }
    void SpawnEnemy( int enemypos)
    {
        GameObject spawnedenemy = Instantiate(enemyPrefab, WayPoints.StartPoint.position, WayPoints.StartPoint.rotation) ;
        //vertical offset
        spawnedenemy.transform.Translate(spawnedenemy.GetComponent<EnemyData>().GetOffset(),Space.World);
;        spawnedenemy.GetComponent<EnemyData>().WaveNumber = waveNumber;
        spawnedenemy.GetComponent<EnemyData>().EnemyPos = enemypos;
    }

}
