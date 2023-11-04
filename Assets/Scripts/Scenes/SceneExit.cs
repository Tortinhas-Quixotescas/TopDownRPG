using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string destinyScene;
    public Vector2 positionInNewScene;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            SceneManager.LoadScene(destinyScene, LoadSceneMode.Single);
            SceneManager.LoadScene("Interface", LoadSceneMode.Additive);
            PlayerController.uniqueInstance.transform.position = this.positionInNewScene;

            MainManager.Instance.animalsContainer.SetActive(destinyScene.Equals("StartingArea"));
        }
    }

}
