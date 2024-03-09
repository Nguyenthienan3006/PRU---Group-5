using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesCount : MonoBehaviour
{
    private string enemyTag = "Enemies";
    private int totalEnemies = 0;
    private int killedEnemies = 0;

    [SerializeField]
    private Text enemiesCountText;

    private void Start()
    {
        // Count total enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        totalEnemies = enemies.Length;
        enemiesCountText.text = "Killed Enemies: " + killedEnemies.ToString() + "/" + totalEnemies.ToString();
    }

    // Call this method whenever an enemy is killed
    public void EnemyKilled()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        killedEnemies++;
        enemiesCountText.text = "Killed Enemies: " + killedEnemies.ToString() + "/" + totalEnemies.ToString();   
    }

    public int TotalEnemies()
    {
        return totalEnemies;
    }

    public int TotalKilledEnemies()
    {
        return killedEnemies;
    }
}
