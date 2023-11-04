using UnityEngine;

public class InteractiveLootController : InteractiveObjectController
{
    public Inventory.InventoryItems itemName;
    public int itemPool = 16;
    public AudioClip pickUpSound;

    override public void Interact()
    {
        if (itemPool > 0)
        {
            AudioSource.PlayClipAtPoint(pickUpSound, this.transform.position);
            if (itemName.Equals(Inventory.InventoryItems.Corn))
            {
                MainManager.Instance.UpdateInventory(Inventory.InventoryItems.Corn);
                itemPool -= MainManager.Instance.inventory.corn.GetIncreaseAmout();
            }
            if (itemName.Equals(Inventory.InventoryItems.Potato))
            {
                MainManager.Instance.UpdateInventory(Inventory.InventoryItems.Potato);
                itemPool -= MainManager.Instance.inventory.potato.GetIncreaseAmout();
            }
            if (itemName.Equals(Inventory.InventoryItems.Tomato))
            {
                MainManager.Instance.UpdateInventory(Inventory.InventoryItems.Tomato);
                itemPool -= MainManager.Instance.inventory.tomato.GetIncreaseAmout();
            }
            if (itemName.Equals(Inventory.InventoryItems.Spinach))
            {
                MainManager.Instance.UpdateInventory(Inventory.InventoryItems.Spinach);
                itemPool -= MainManager.Instance.inventory.spinach.GetIncreaseAmout();
            }
            if (itemName.Equals(Inventory.InventoryItems.Egg))
            {
                MainManager.Instance.UpdateInventory(Inventory.InventoryItems.Egg);
                itemPool -= MainManager.Instance.inventory.egg.GetIncreaseAmout();
            }
        }
    }
}
