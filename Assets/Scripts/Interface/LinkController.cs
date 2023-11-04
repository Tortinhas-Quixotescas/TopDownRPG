using UnityEngine;
using UnityEngine.EventSystems;

public class LinkController : MonoBehaviour, IPointerClickHandler
{
    public string url;

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(url);
    }

}