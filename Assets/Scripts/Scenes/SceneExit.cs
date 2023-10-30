using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string destinyScene;
    public string areaTransitionName;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            SceneManager.LoadScene(destinyScene, LoadSceneMode.Single);
            SceneManager.LoadScene("Interface", LoadSceneMode.Additive);
            PlayerController.uniqueInstance.areaTransitionName = areaTransitionName;
        }
    }
}
