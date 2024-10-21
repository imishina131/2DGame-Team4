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
}
