using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Transform itemsPanel;
    private TMP_Text chickenMeatQuantityText;
    private TMP_Text cowMeatQuantityText;
    private TMP_Text pigMeatQuantityText;

    private void Awake()
    {
        this.itemsPanel = this.transform.GetChild(1);
        this.chickenMeatQuantityText = itemsPanel.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        this.cowMeatQuantityText = itemsPanel.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        this.pigMeatQuantityText = itemsPanel.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
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
        ); this.pigMeatQuantityText.SetText(
            MainManager.Instance.inventory.pigMeat.GetCurrentQuantity().ToString().PadLeft(2, '0')
            + "/"
            + MainManager.Instance.inventory.pigMeat.GetMaxQuantity().ToString().PadLeft(2, '0')
        );
    }

}
