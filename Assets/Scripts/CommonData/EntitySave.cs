using UnityEngine;

public class EntitySave
{
    private Transform transform;
    private Vector2 lastPosition;

    public EntitySave(Transform transform, Vector2 lastPosition)
    {
        this.transform = transform;
        this.lastPosition = lastPosition;
    }

    public Transform GetTransform()
    {
        return this.transform;
    }

}
