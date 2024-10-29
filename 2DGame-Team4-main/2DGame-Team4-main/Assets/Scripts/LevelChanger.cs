using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public void FadeOut()
    {
        StartCoroutine(ChangeLevel());
    }

    IEnumerator ChangeLevel()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Level01"))
        {
            SceneManager.LoadScene(3);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("Level02"))
        {
            SceneManager.LoadScene(4);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("WinScene01"))
        {
            SceneManager.LoadScene(5);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("WinScene02"))
        {
            SceneManager.LoadScene(6);
        }
    }
}
