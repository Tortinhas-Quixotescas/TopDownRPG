using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject creditsScreen;

    public void StartGame()
    {
        MainManager.Instance.RestartGame();
        SceneManager.LoadScene("StartingArea", LoadSceneMode.Single);
        SceneManager.LoadScene("Interface", LoadSceneMode.Additive);
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void CreditsController(Boolean close)
    {
        creditsScreen.SetActive(!close);
    }

}
