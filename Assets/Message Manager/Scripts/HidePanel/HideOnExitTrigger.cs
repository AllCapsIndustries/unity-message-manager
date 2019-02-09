using UnityEngine;
using UnityEngine.EventSystems;

public class HideOnExitTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInParent<HideOnCursorExit>().UnHide();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInParent<HideOnCursorExit>().Hide();
    }
}
