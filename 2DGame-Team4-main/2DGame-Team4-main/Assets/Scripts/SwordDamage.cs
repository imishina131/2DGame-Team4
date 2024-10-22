using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<Goblin>(out Goblin goblinComponent))
        {
            goblinComponent.TakeDamage();
        }
    }
}
