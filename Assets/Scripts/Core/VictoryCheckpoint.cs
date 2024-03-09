using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryCheckpoint : MonoBehaviour
{
    [SerializeField] private AudioClip victorySound;
    private bool levelCompleted = false;
    [SerializeField] private Text warning;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            GameObject myObject = GameObject.Find("EnemiesCount");
            var enemiesCount = myObject.GetComponent<EnemiesCount>();

            if (enemiesCount.TotalKilledEnemies() == enemiesCount.TotalEnemies())
            {
                SoundManager.instance.PlaySound(victorySound);
                levelCompleted = true;
                Invoke("CompleteLevel", 2f);
            }
            else
            {
                StartCoroutine(Warning());
            }
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator Warning()
    {
        warning.text = "You must kill all enemies before go to next level!";

        //Wait until X seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(1);
        warning.text = string.Empty;
    }
}
