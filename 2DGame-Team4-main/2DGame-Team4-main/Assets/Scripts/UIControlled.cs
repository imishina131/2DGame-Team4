using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControlled : MonoBehaviour
{
    public GameObject explanationPanel;
    public LevelChanger levelChange;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "WinScene01")
        {
            StartCoroutine(LoadWinScene2());
        }
        if(SceneManager.GetActiveScene().name == "WinScene02")
        {
            explanationPanel.gameObject.SetActive(false);
            StartCoroutine(LoadExplanation());
        }
    }
    IEnumerator LoadExplanation()
    {
        yield return new WaitForSeconds(5);
        explanationPanel.gameObject.SetActive(true);
        StartCoroutine(LoadCredits());
    }

    IEnumerator LoadCredits()
    {
        yield return new WaitForSeconds(15);
        levelChange.FadeOut();
    }

    IEnumerator LoadWinScene2()
    {
        yield return new WaitForSeconds(5);
        levelChange.FadeOut();
    }
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
