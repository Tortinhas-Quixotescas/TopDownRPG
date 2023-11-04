using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Transform itemsPanel;
    [SerializeField] private TMP_Text chickenMeatQuantityText;
    private TMP_Text cowMeatQuantityText;
    private TMP_Text pigMeatQuantityText;
    private TMP_Text cornQuantityText;
    private TMP_Text potatoQuantityText;
    private TMP_Text tomatoQuantityText;
    private TMP_Text spinachQuantityText;
    private TMP_Text eggQuantityText;

    private void Awake()
    {
        this.itemsPanel = this.transform.GetChild(1);
        this.chickenMeatQuantityText = itemsPanel.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        this.cowMeatQuantityText = itemsPanel.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        this.pigMeatQuantityText = itemsPanel.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        this.cornQuantityText = itemsPanel.GetChild(3).GetChild(1).GetComponent<TMP_Text>();
        this.potatoQuantityText = itemsPanel.GetChild(4).GetChild(1).GetComponent<TMP_Text>();
        this.tomatoQuantityText = itemsPanel.GetChild(5).GetChild(1).GetComponent<TMP_Text>();
        this.spinachQuantityText = itemsPanel.GetChild(6).GetChild(1).GetComponent<TMP_Text>();
        this.eggQuantityText = itemsPanel.GetChild(7).GetChild(1).GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        this.chickenMeatQuantityText.SetText(
            MainManager.Instance.inventory.chickenMeat.GetCurrentQuantity().ToString().PadLeft(2, '0')
            + "/"
            + MainManager.Instance.inventory.chickenMeat.GetMaxQuantity().ToString().PadLeft(2, '0')
        );
        this.cowMeatQuantityText.SetText(
            MainManager.Instance.inventory.cowMeat.GetCurrentQuantity().ToString().PadLeft(2, '0')
            + "/"
            + MainManager.Instance.inventory.cowMeat.GetMaxQuantity().ToString().PadLeft(2, '0')
        );
        this.pigMeatQuantityText.SetText(
            MainManager.Instance.inventory.pigMeat.GetCurrentQuantity().ToString().PadLeft(2, '0')
            + "/"
            + MainManager.Instance.inventory.pigMeat.GetMaxQuantity().ToString().PadLeft(2, '0')
        );
        this.cornQuantityText.SetText(
            MainManager.Instance.inventory.corn.GetCurrentQuantity().ToString().PadLeft(2, '0')
            + "/"
            + MainManager.Instance.inventory.corn.GetMaxQuantity().ToString().PadLeft(2, '0')
        );
        this.potatoQuantityText.SetText(
            MainManager.Instance.inventory.potato.GetCurrentQuantity().ToString().PadLeft(2, '0')
            + "/"
            + MainManager.Instance.inventory.potato.GetMaxQuantity().ToString().PadLeft(2, '0')
        );
        this.tomatoQuantityText.SetText(
            MainManager.Instance.inventory.tomato.GetCurrentQuantity().ToString().PadLeft(2, '0')
            + "/"
            + MainManager.Instance.inventory.tomato.GetMaxQuantity().ToString().PadLeft(2, '0')
        );
        this.spinachQuantityText.SetText(
            MainManager.Instance.inventory.spinach.GetCurrentQuantity().ToString().PadLeft(2, '0')
            + "/"
            + MainManager.Instance.inventory.spinach.GetMaxQuantity().ToString().PadLeft(2, '0')
        );
        this.eggQuantityText.SetText(
            MainManager.Instance.inventory.egg.GetCurrentQuantity().ToString().PadLeft(2, '0')
            + "/"
            + MainManager.Instance.inventory.egg.GetMaxQuantity().ToString().PadLeft(2, '0')
        );
    }

}
