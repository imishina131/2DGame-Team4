using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public int health = 50;
    public Player player;

    public void TakeDamage()
    {
        health -= 10;
        Debug.Log("Goblin: " + health);

        if(health <= 0)
        {
            Destroy(gameObject);
            player.enemiesKilled ++;
        }
    }
}
