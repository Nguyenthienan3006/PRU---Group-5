using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void RespawnCheck()
    {
        playerHealth.Respawn();
        if(SceneManager.GetActiveScene().name == "Scene 3 - Secret Castle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (currentCheckpoint == null)
        {
            transform.position = GameObject.FindGameObjectWithTag("StartPoint").transform.position;
        } 
        else
        {
            transform.position = currentCheckpoint.position; //Move player to checkpoint location
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("activate");
        }
        else if (collision.gameObject.tag == "StartPoint")
        {
            SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("activate");
        }
    }
}
