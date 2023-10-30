using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInterfaceController : MonoBehaviour
{

    public GameObject timer;
    public GameObject inventory;
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
            bool currentState = this.inventory.active;
            this.inventory.SetActive(!currentState);
            Time.timeScale = currentState == true ? 1 : 0;
        }
    }

}
