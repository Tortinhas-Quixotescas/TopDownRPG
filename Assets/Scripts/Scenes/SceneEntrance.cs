using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public string transitionName;

    void Start()
    {
        if (transitionName == PlayerController.uniqueInstance.areaTransitionName)
            PlayerController.uniqueInstance.transform.position = transform.position;
    }

}
