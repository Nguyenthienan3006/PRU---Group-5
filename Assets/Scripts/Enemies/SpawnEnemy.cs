using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabEnemies;

    // spawn control
    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;
    Timer spawnTimer;

    // spawn location support
    const int SpawnBorderSize = 100;
    float minSpawnX;
    float maxSpawnX;
    float SpawnY;
    int limit;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // save spawn boundaries for efficiency
        minSpawnX = 47.02f;
        maxSpawnX = 65.86f;
        SpawnY = -8.84f;
        limit = 1;
        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // check for time to spawn a new teddy bear
        if (spawnTimer.Finished && limit<=4)
        {
            SpawnEnemiy();
            limit++;
            // change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    /// <summary>
    /// Spawns a new teddy bear at a random location
    /// </summary>
    void SpawnEnemiy()
    {
        // generate random location and create new teddy bear
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
            SpawnY,
            -0.03995441f);
        GameObject enemies = Instantiate(prefabEnemies) as GameObject;
        enemies.transform.position = location;
    }
}
