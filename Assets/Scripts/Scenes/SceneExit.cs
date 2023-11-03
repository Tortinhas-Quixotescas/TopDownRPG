using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{

    public string destinyScene;
    public Vector2 positionInNewScene;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.name.Equals("StartingArea"))
            {
                MainManager.Instance.animals.SetActive(false);
            }
            else if (destinyScene.Equals("StartingArea"))
            {
                MainManager.Instance.animals.SetActive(true);
            }

            SceneManager.LoadScene(destinyScene, LoadSceneMode.Single);
            SceneManager.LoadScene("Interface", LoadSceneMode.Additive);
            PlayerController.uniqueInstance.transform.position = this.positionInNewScene;
        }
    }

}