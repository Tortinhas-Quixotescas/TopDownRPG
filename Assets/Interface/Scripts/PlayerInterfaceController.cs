using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInterfaceController : MonoBehaviour
{

    public GameObject timer;
    public float remainingTime;

    private TMP_Text timerTMP;

    private void Start()
    {
        this.timerTMP = timer.GetComponent<TMP_Text>();
        this.timerTMP.SetText(this.remainingTime.ToString().PadLeft(3, '0'));

        InvokeRepeating("DecreaseTimeRemaining", 1.0f, 1.0f);
    }

    private void DecreaseTimeRemaining()
    {
        this.remainingTime--;
        this.timerTMP.SetText(this.remainingTime.ToString().PadLeft(3, '0'));

        if (this.remainingTime <= 0)
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

}
