using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectController : MonoBehaviour
{
    public string itemName;
    public int itemPool = 5;

    public AudioClip pickUpSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetItem()
    {
        if (itemPool > 0)
        {
            AudioSource.PlayClipAtPoint(pickUpSound, transform.position);
            --itemPool;
            return this.itemName;
        }
        else
            return null;
    }
}
