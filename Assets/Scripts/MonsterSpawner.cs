using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public int numberToSpawn = 10;
    public int EnemiesLeft { get { return enemiesLeft; } }
    int enemiesLeft;
    [Range(2, 7)]public float spawnInterval = 3.0f;
    [Range(0, 2)]public float spawnIntervalRange = 1.0f;
    float nextSpawnInterval;
    float spawnTimer;
    public List<Enemy> possibleEnemies = new List<Enemy>();

    public bool finishedSpawning { get { return finished; } }
    bool finished = false;


    //                ---TODO---

    // 1. Make sure enemies pursue the player correctly
    //      a. and in the right direction
    // 2. Make sure enemies face the right direction
    // 3. When out of enemies to spawn, do something
    //
    //


    private void Start()
    {
        //set local variable
        enemiesLeft = numberToSpawn;
        //set local spawn interval to a random value within the set range (abs makes it always positive)
        nextSpawnInterval = Mathf.Abs( Random.Range(spawnInterval - spawnIntervalRange, spawnInterval + spawnIntervalRange) );
    }

    private void Update()
    {
        if (enemiesLeft == 0) finished = true;
        //Add up the timer
        spawnTimer += Time.deltaTime;
        //If timer is ready to spawn another enemy
        if(spawnTimer >= nextSpawnInterval)
        {
            //Spawn
            SpawnEnemy();
            //Find a new random interval within range
            nextSpawnInterval = Mathf.Abs( Random.Range(spawnInterval - spawnIntervalRange, spawnInterval + spawnIntervalRange));
        }
    }
    /// <summary>
    /// This method spawns an enemy from the list of possible enemies
    /// </summary>
    void SpawnEnemy()
    {
        spawnTimer = 0;
        int enemyIndex = Random.Range(0, possibleEnemies.Count - 1);
        //create new enemy
        Instantiate(possibleEnemies[enemyIndex]);
        enemiesLeft--;
    }
}
