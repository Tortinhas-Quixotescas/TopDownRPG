using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int remainingTime;
    public Inventory inventory;

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

    public void UpdateInventory(Inventory.InventoryItems item, int difference)
    {
        switch (item)
        {
            case Inventory.InventoryItems.ChickenMeat:
                this.inventory.chickenMeat = Math.Max(this.inventory.chickenMeat + difference, 0);
                break;
            case Inventory.InventoryItems.CowMeat:
                this.inventory.cowMeat = Math.Max(this.inventory.cowMeat + difference, 0);
                break;
            case Inventory.InventoryItems.PigMeat:
                this.inventory.pigMeat = Math.Max(this.inventory.pigMeat + difference, 0);
                break;
        }
    }

}
