using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LinkController : MonoBehaviour, IPointerClickHandler
{

    public String url;

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(url);
    }

}