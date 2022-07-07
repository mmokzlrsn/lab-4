using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<GameObject> pickupPrefabs;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 16.0f;
    private float zPickupRange = 5.0f;
    private float ySpawn = 0.75f;

    private float pickupSpawnTime = 5.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPickup", startDelay, pickupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemyPrefabs.Count);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemyPrefabs[randomIndex], spawnPos, enemyPrefabs[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPickup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPickupRange, zPickupRange);
        int randomIndex = Random.Range(0, pickupPrefabs.Count);


        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);
        Instantiate(pickupPrefabs[randomIndex], spawnPos, pickupPrefabs[randomIndex].gameObject.transform.rotation);
    }
}
