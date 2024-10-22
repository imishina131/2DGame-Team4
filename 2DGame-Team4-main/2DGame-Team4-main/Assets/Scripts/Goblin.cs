using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public int health = 50;


    public void TakeDamage()
    {
        health -= 25;
        Debug.Log("Goblin: " + health);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
