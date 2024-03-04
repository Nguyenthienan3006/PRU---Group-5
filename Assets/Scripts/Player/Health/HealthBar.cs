using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private float startingHealth;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
        startingHealth = playerHealth.currentHealth;
    }
    private void Update()
    {
        if (playerHealth.currentHealth > startingHealth)
        {
            totalhealthBar.fillAmount = (float)Math.Ceiling(playerHealth.currentHealth) / 10;
        }
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
