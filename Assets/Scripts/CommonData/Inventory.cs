public class Inventory
{
    public enum InventoryItems
    {
        ChickenMeat,
        CowMeat,
        PigMeat
    }

    public int chickenMeat;
    public int cowMeat;
    public int pigMeat;

    public Inventory()
    {
        this.chickenMeat = 0;
        this.cowMeat = 0;
        this.pigMeat = 0;
    }

}
