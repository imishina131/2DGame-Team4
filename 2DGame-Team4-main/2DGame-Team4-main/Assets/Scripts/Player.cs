using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 100;
    bool isShielded;




    public void TakeDamage()
    {
        if(isShielded)
        {
            return;
        }
        else
        {
            health -= 10;
        }
    }
}
