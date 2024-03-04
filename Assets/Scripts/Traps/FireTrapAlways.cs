using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapAlways : MonoBehaviour
{
    [Header("Damage")]
    // Start is called before the first frame update
    [SerializeField] private float damage;

    private Animator anim;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip firetrapSound;

    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("activated", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();
            playerHealth.TakeDamage(damage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerHealth = null;
    }
}
