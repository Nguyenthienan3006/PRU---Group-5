using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar1 : MonoBehaviour
{
    [SerializeField] private GameObject[] health1;
    [SerializeField] private Health playerHealth1;

    [Header("Heart Prefab")]
    [SerializeField] private GameObject heartPrefab; // Prefab của trái tim
    private bool heartDropped = false; // Biến cờ để kiểm tra trái tim đã được tạo ra hay chưa

    // Update is called once per frame
    void Update()
    {
        if (playerHealth1.currentHealth < health1.Length && playerHealth1.currentHealth >= 0)
        {
            for (int i = health1.Length - 1; i >= playerHealth1.currentHealth; i--)
            {
                health1[i].GetComponent<SpriteRenderer>().color = Color.black;
            }
        }

        // Drop heart when enemy is killed
        if (playerHealth1.currentHealth <= 0 && !heartDropped)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
            heartDropped = true; // Đặt biến cờ thành true để chỉ tạo ra một trái tim
        }
    }
}
