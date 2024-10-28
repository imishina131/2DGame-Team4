using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    static int health;
    static int maxHealth;
    public bool isShielded;
    Animator animator;
    private AudioSource audioSource;
    public AudioClip block;
    public AudioClip gethit;
    public AudioClip die;
    public HealthBarScript healthBar;
    public int enemiesKilled = 0;
    

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level01")
        {
            health = 100;
            maxHealth = 100;
            healthBar.SetMaxHealth(maxHealth);
        }
        healthBar.SetHealth(health);
        Debug.Log("Health: " + health);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }



    public void TakeDamage(int damage)
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
                health -= damage;
                audioSource.clip = gethit;
                audioSource.Play();
                healthBar.SetHealth(health);
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
        if(health <= 80)
        {
            health += 20;
        }
        else if(health > 80)
        {
            health = maxHealth;
        }
        healthBar.SetHealth(health);
    }

    public void SetHealthForBoss()
    {
        maxHealth = 200;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    IEnumerator Death()
    {
        animator.SetTrigger("death");
        audioSource.clip = die;
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        maxHealth = 100;
        health = maxHealth;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TriggerDeath()
    {
        StartCoroutine(Death());
    }

}
