using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int remainingTime;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InvokeRepeating("DecreaseTimeRemaining", 0, 1);
    }

    private void DecreaseTimeRemaining()
    {
        this.remainingTime--;
        if (this.remainingTime <= 0)
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

}
