using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    public AudioClip lootPickup;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(lootPickup, transform.position);
            gameObject.SetActive(false);
        }
    }
}
