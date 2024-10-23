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
    }

    public void OnClikBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClikHelpButton()
    {
        SceneManager.LoadScene("HelpMenu");
    }

    public void OnClikCreditsButton()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
}
