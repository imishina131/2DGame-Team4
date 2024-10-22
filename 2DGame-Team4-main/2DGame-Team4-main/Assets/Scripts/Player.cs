using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int health = 100;
    bool isShielded = false;
    Scene currentScene;
    string sceneName;
    

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }


    public void TakeDamage()
    {
        if(isShielded)
        {
            return;
        }
        else
        {
            health -= 10;
            Debug.Log(health);
        }
    }

    public void Block()
    {
        isShielded = true;
    }

    public void Attack()
    {
        if(sceneName == "Level01")
        {

        }
        else if(sceneName == "Level02")
        {

        }
    }
}
