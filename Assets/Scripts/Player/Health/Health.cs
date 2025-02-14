using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private Rigidbody2D rb;

    [Header("iFrames Properties")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    public bool invulnerable =false;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;

        currentHealth = currentHealth - _damage;

        if(currentHealth <= 10)
        {
            anim.SetBool("isEnraged",true);
        }
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {
                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                    component.enabled = false;
                
                anim.SetTrigger("die");
                SoundManager.instance.PlaySound(deathSound);
                dead = true;

                if (gameObject.tag != null && !gameObject.CompareTag("Player"))
                {
                    GameObject myObject = GameObject.Find("EnemiesCount");
                    if (myObject != null)
                    {
                        var enemiesCount = myObject.GetComponent<EnemiesCount>();
                        enemiesCount.EnemyKilled();
                    }
                }
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = currentHealth + _value;
    }

    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    //Respawn
    public void Respawn()
    {
        currentHealth = 3;
        anim.ResetTrigger("die");
        anim.Play("Idle");
        StartCoroutine(Invunerability());
        dead = false;
        rb.bodyType = RigidbodyType2D.Dynamic;

        //Activate all attached component classes
        foreach (Behaviour component in components)
            component.enabled = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
