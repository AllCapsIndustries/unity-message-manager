using UnityEngine;
using UnityEngine.EventSystems;

public class ResizePanel : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler {
    public Vector2 minSize;
    public Vector2 maxSize;
    internal bool resizing;

    private RectTransform rectTransform;
    private Vector2 currentPointerPosition;
    private Vector2 previousPointerPosition;
    private bool _debug;

    void Awake () {
        rectTransform = transform.parent.GetComponent<RectTransform> ();
    }

    public void OnPointerDown (PointerEventData data) {
        rectTransform.SetAsLastSibling ();
        RectTransformUtility.ScreenPointToLocalPointInRectangle (rectTransform, data.position, data.pressEventCamera, out previousPointerPosition);
    }

    public void OnDrag (PointerEventData data) {
        if (rectTransform == null)
            return;

        resizing = true;

        Vector2 sizeDelta = rectTransform.sizeDelta;

        RectTransformUtility.ScreenPointToLocalPointInRectangle (rectTransform, data.position, data.pressEventCamera, out currentPointerPosition);
        Vector2 resizeValue = currentPointerPosition - previousPointerPosition;

        sizeDelta += new Vector2 (resizeValue.x, -resizeValue.y);
        sizeDelta = new Vector2 (
            Mathf.Clamp (sizeDelta.x, minSize.x, maxSize.x),
            Mathf.Clamp (sizeDelta.y, minSize.y, maxSize.y)
        );

        rectTransform.sizeDelta = sizeDelta;

        previousPointerPosition = currentPointerPosition;
    }

    public void OnEndDrag (PointerEventData eventData) {
        if (_debug)
            print ("ResizePanel: OnEndDrag: Running SavePanel()");

        resizing = false;
    }
}