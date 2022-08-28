using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Wave
{
    public string waveName;
    public int NumberOfEnemies;
    public EnemyWaveData[] typeOfEnemies;
    public float spawnInterval;



}
[System.Serializable]
public struct EnemyWaveData
{
    public GameObject Enemy;
    public int Count;
}

public class WaveGenerator : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currentWave;
    public int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;

    //public GameObject zeus;
    
    

   /* private void Start()
    {
        
        zeus.SetActive(false);
    }*/

    private void Update()
    {
        
        
        
        
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
        {
            SpawnNextWave();
        }
        
    }
    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
    if (canSpawn && nextSpawnTime < Time.time)
        {
        GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)].Enemy;
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
        currentWave.NumberOfEnemies --;
        nextSpawnTime = Time.time + currentWave.spawnInterval;
        if (currentWave.NumberOfEnemies == 0)
            {
            canSpawn = false;
            }
        }
    }



}
