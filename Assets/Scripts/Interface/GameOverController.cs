using UnityEngine.SceneManagement;

public class GameOverController : InventoryController
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
