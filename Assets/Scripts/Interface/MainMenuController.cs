using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject creditsScreen;

    public void StartGame()
    {
        // SceneManager.LoadScene("Loader", LoadSceneMode.Single);
        MainManager.Instance.RestartGame();
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
