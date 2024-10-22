using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public int health = 50;


    public void TakeDamage()
    {
        health -= 25;
    }
}
