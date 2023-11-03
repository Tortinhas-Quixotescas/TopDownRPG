using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int remainingTime;
    public Inventory inventory;
    public GameObject animals;
    public GameObject animalsPrefab;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        this.inventory = new Inventory();
        this.animals = Instantiate(animalsPrefab);
        DontDestroyOnLoad(this.animals);
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

    public void UpdateInventory(Inventory.InventoryItems item)
    {
        switch (item)
        {
            case Inventory.InventoryItems.ChickenMeat:
                this.inventory.chickenMeat.IncreaseCurrentQuantity();
                break;
            case Inventory.InventoryItems.CowMeat:
                this.inventory.cowMeat.IncreaseCurrentQuantity();
                break;
            case Inventory.InventoryItems.PigMeat:
                this.inventory.pigMeat.IncreaseCurrentQuantity();
                break;
        }
    }

    // public void SaveEntities(GameObject parent)
    // {
    //     DontDestroyOnLoad(parent);
    //     parent.SetActive(false);
    // }

}
