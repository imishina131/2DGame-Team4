using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public AudioClip slash;
    public AudioClip hit;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<Goblin>(out Goblin goblinComponent))
        {
            goblinComponent.TakeDamage();
            audioSource.clip = hit;
            audioSource.Play();
        }
        else if(other.gameObject.TryGetComponent<Skeleton>(out Skeleton skeletonComponent))
        {
            skeletonComponent.TakeDamage();
            audioSource.clip = hit;
            audioSource.Play();
        }
    }
}
