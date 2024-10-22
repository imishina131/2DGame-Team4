using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public int health = 100;


    public void TakeDamage()
    {
        health -= 25;
    }
}
