using System;

public class Inventory
{
    public enum InventoryItems
    {
        ChickenMeat,
        CowMeat,
        PigMeat
    }

    public LootItem chickenMeat;
    public LootItem cowMeat;
    public LootItem pigMeat;

    public Inventory()
    {
        this.chickenMeat = new LootItem(5, 1);
        this.cowMeat = new LootItem(12, 4);
        this.pigMeat = new LootItem(8, 2);
    }

}

public class LootItem
{
    private int currentQuantity;
    private int maxQuantity;
    private int increaseAmount;

    public LootItem(int maxQuantity, int increaseAmount)
    {
        this.currentQuantity = 0;
        this.maxQuantity = maxQuantity;
        this.increaseAmount = increaseAmount;
    }

    public int GetCurrentQuantity()
    {
        return this.currentQuantity;
    }

    public int GetMaxQuantity()
    {
        return this.maxQuantity;
    }

    // public void SetCurrentQuantity(int quantity)
    // {
    //     this.currentQuantity = Math.Max(quantity, 0);
    // }

    public void IncreaseCurrentQuantity()
    {
        this.currentQuantity = this.currentQuantity + this.increaseAmount;
    }
}
