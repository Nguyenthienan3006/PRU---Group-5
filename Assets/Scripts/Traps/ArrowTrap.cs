using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject[] arrows;
    private float cooldownTimer;

    [Header("Sound Effect")]
    [SerializeField] private AudioClip arrowSound;

    private void Attack()
    {
        cooldownTimer = 0;

        SoundManager.instance.PlaySound(arrowSound);
        arrows[FindArrow()].transform.position = point.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCooldown)
            Attack();
    }
}
