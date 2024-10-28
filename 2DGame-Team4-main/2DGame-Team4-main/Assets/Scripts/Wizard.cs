using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wizard : MonoBehaviour
{
    public int health = 200;
    public Player player;

    public void TakeDamage()
    {
        health -= 20;

        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(4);
        }
    }
}
