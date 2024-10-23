using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSword : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if(other.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            Debug.Log("hit");
            playerComponent.TakeDamage();
        }

    }
}