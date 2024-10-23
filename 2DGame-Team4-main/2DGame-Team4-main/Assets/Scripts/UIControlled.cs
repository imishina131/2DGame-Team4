using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControlled : MonoBehaviour
{

    public void OnClickPlayButton()
    {
        SceneManager.LoadSceneAsync("Level01");
    }

    public void OnclickQuitButton()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void OnClickHelpButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickCreditsButton()
    {
        SceneManager.LoadScene(4);
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene(0);
    }
}
