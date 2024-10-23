using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int health = 75;


    public void TakeDamage()
    {
        health -= 25;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
