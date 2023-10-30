public class Inventory
{
    public enum InventoryItems
    {
        ChickenMeat,
        CowMeat
    }

    public int chickenMeat;
    public int cowMeat;

    public Inventory()
    {
        this.chickenMeat = 0;
        this.cowMeat = 0;
    }

}
