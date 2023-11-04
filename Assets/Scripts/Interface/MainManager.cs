using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public int limitTime;
    public int remainingTime;
    public Inventory inventory;
    public GameObject animalsPrefab;
    public GameObject meatContainer;
    public GameObject animalsContainer;
    public GameObject gameOverScreen;

    public void RestartGame()
    {
        this.remainingTime = this.limitTime;
        this.inventory = new Inventory();
        Destroy(this.animalsContainer);
        this.animalsContainer = Instantiate(animalsPrefab);
        DontDestroyOnLoad(animalsContainer);
        DontDestroyOnLoad(meatContainer);
        InvokeRepeating("DecreaseTimeRemaining", 0, 1);
        Time.timeScale = 1;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // TODO: Remove in final version
        this.RestartGame();
    }

    private void DecreaseTimeRemaining()
    {
        this.remainingTime--;
        if (this.remainingTime <= 0)
        {
            this.gameOverScreen.SetActive(true);
            Time.timeScale = 0;
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
            case Inventory.InventoryItems.Corn:
                this.inventory.corn.IncreaseCurrentQuantity();
                break;
            case Inventory.InventoryItems.Potato:
                this.inventory.potato.IncreaseCurrentQuantity();
                break;
            case Inventory.InventoryItems.Tomato:
                this.inventory.tomato.IncreaseCurrentQuantity();
                break;
            case Inventory.InventoryItems.Spinach:
                this.inventory.spinach.IncreaseCurrentQuantity();
                break;
            case Inventory.InventoryItems.Egg:
                this.inventory.egg.IncreaseCurrentQuantity();
                break;
        }
    }

}
