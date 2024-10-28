using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int health = 105;


    public void TakeDamage()
    {
        health -= 15;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
