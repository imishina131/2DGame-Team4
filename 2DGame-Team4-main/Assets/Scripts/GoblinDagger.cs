using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDagger : MonoBehaviour
{


   void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit");
        if(other.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            Debug.Log("hit");
            playerComponent.TakeDamage();
        }

    }
}
