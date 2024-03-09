using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject[] health;
    [SerializeField] private Health playerHealth;

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentHealth < health.Length && playerHealth.currentHealth >= 0)
        {
            for (int i = health.Length - 1; i >= playerHealth.currentHealth; i--)
            {
                health[i].GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }
}
