public class Inventory
{
    public enum InventoryItems
    {
        ChickenMeat,
        CowMeat,
        PigMeat,
        Corn,
        Potato,
        Tomato,
        Spinach,
        Egg
    }

    public LootItem chickenMeat;
    public LootItem cowMeat;
    public LootItem pigMeat;
    public LootItem corn;
    public LootItem potato;
    public LootItem tomato;
    public LootItem spinach;
    public LootItem egg;

    public Inventory()
    {
        this.chickenMeat = new LootItem(5, 1);
        this.cowMeat = new LootItem(12, 4);
        this.pigMeat = new LootItem(8, 2);
        this.corn = new LootItem(6, 1);
        this.potato = new LootItem(10, 1);
        this.tomato = new LootItem(16, 1);
        this.spinach = new LootItem(4, 1);
        this.egg = new LootItem(12, 2);
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

    public int GetIncreaseAmout()
    {
        return this.increaseAmount;
    }

    public void IncreaseCurrentQuantity()
    {
        this.currentQuantity = this.currentQuantity + this.increaseAmount;
    }
}
