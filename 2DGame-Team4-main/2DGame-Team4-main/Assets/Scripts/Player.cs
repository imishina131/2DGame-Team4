using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    int health = 100;
    public bool isShielded;
    Animator animator;
    private AudioSource audioSource;
    public AudioClip block;
    public AudioClip gethit;
    public AudioClip die;
    public TMP_Text playerHealth;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerHealth.text = "Health: " + health;
    }



    public void TakeDamage()
    {
        Debug.Log(isShielded);
        if(isShielded)
        {
            audioSource.clip = block;
            audioSource.Play();
            return;
        }
        else
        {
            if(health > 0)
            {
                health -= 10;
                audioSource.clip = gethit;
                audioSource.Play();
                Debug.Log(health);
                playerHealth.text = "Health: " + health;
            }
        }

        if(health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public void Block()
    {
        Debug.Log("Block()");
        isShielded = true;
    }

    public void Unshield()
    {
        Debug.Log("Unshield()");
        isShielded = false;
    }

    public void GainHealth()
    {
        health += 20;
        playerHealth.text = "Health: " + health;
    }

    IEnumerator Death()
    {
        animator.SetTrigger("death");
        audioSource.clip = die;
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TriggerDeath()
    {
        StartCoroutine(Death());
    }

}
