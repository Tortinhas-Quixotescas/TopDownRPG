using TMPro;
using UnityEngine;

public class PlayerInterfaceController : MonoBehaviour
{
    public GameObject timer;
    public GameObject inventoryPanel;
    public GameObject FinishGamePanel;
    private TMP_Text timerTMP;

    private void Start()
    {
        this.timerTMP = timer.GetComponent<TMP_Text>();
        this.timerTMP.SetText(MainManager.Instance.remainingTime.ToString().PadLeft(3, '0'));
    }

    private void Update()
    {
        this.timerTMP.SetText(MainManager.Instance.remainingTime.ToString().PadLeft(3, '0'));
        bool inventoryChange = Input.GetKeyDown(KeyCode.E);
        if (inventoryChange)
        {
            bool currentState = this.inventoryPanel.active;
            this.inventoryPanel.SetActive(!currentState);
            Time.timeScale = currentState == true ? 1 : 0;
        }
    }

    public void ShowFinishGamePanel(bool victory)
    {
        TMP_Text title = this.FinishGamePanel.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        title.SetText(victory ? "You Won!" : "Game Over");
        this.FinishGamePanel.SetActive(true);
    }

}
