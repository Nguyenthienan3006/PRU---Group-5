using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // needed for spawning
    [SerializeField]
    GameObject prefabEnemies;
    [SerializeField]
    GameObject prefabEnemies2;

    // spawn control
    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;
    Timer spawnTimer;

    // spawn location support
    int limit;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // save spawn boundaries for efficiency
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
        if (spawnTimer.Finished && limit<=8)
        {
            SpawnEnemies();
            limit++;
            // change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    /// <summary>
    /// Spawns a new teddy bear at a random location
    /// </summary>
    void SpawnEnemies()
    {
        // generate random location and create new teddy bear
        Vector3 location;
        Vector3 location2;
        int spriteNumber = Random.Range(0, 2);
        if(spriteNumber == 0)
        {
            GameObject enemies = Instantiate(prefabEnemies) as GameObject;
            location = new Vector3(Random.Range(54.02f, 65.86f),
            -8.84f, -0.03995441f);
            location2 = new Vector3(Random.Range(35.43f, 38.69f),
            -3.84f, -0.03995441f); ;
            int locationNumber = Random.Range(0, 2);
            if(locationNumber == 0)
            {
                enemies.transform.position = location;
            }
            else
            {
                enemies.transform.position = location2;
            }

        }
        else
        {
            GameObject enemies = Instantiate(prefabEnemies2) as GameObject;
            location = new Vector3(Random.Range(55.57f, 59.18f),
            -7.88f, -4.113077f);
            location2 = new Vector3(Random.Range(35f, 38.68f),
            -2.66f, -4.113077f); ;
            int locationNumber = Random.Range(0, 2);
            if (locationNumber == 0)
            {
                enemies.transform.position = location;
            }
            else
            {
                enemies.transform.position = location2;
            }
        }
    }
}
