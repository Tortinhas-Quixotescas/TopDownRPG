using UnityEngine.SceneManagement;

public class FinishGameController : InventoryController
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
