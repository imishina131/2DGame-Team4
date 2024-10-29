using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wizard : MonoBehaviour
{
    public int health = 200;
    public Player player;
    public Animator animator;
    public LevelChanger levelChange;

    public void TakeDamage()
    {
        health -= 20;

        if(health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(2.2f);
        levelChange.FadeOut();
    }
}
