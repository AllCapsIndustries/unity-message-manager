﻿using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler {
    //private ControlCanvasSerialization canvasSerialization;

    private Vector2 pointerOffset;
    private RectTransform canvasRectTransform;
    private RectTransform panelRectTransform;
    internal bool dragging;

    void Awake () {
        Canvas canvas = GetComponentInParent<Canvas> ();
        //canvasSerialization = GetComponentInParent<ControlCanvasSerialization> ();
        if (canvas != null) {
            canvasRectTransform = canvas.transform as RectTransform;
            panelRectTransform = transform.parent as RectTransform;
        }
    }

    public void OnPointerDown (PointerEventData data) {
        panelRectTransform.SetAsLastSibling ();
        RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);

        //So we don't have to press escape after every adjustment to UI
        EventSystem.current.SetSelectedGameObject (gameObject);

        //LockInput (true);
    }

    public void OnDrag (PointerEventData data) {
        if (panelRectTransform == null)
            return;

        dragging = true;

        Vector2 pointerPostion = ClampToWindow (data);

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
                canvasRectTransform, pointerPostion, data.pressEventCamera, out localPointerPosition
            )) {
            panelRectTransform.localPosition = localPointerPosition - pointerOffset;
        }
    }

    Vector2 ClampToWindow (PointerEventData data) {
        Vector2 rawPointerPosition = data.position;

        Vector3[] canvasCorners = new Vector3[4];
        canvasRectTransform.GetWorldCorners (canvasCorners);

        float clampedX = Mathf.Clamp (rawPointerPosition.x, canvasCorners[0].x, canvasCorners[2].x);
        float clampedY = Mathf.Clamp (rawPointerPosition.y, canvasCorners[0].y, canvasCorners[2].y);

        Vector2 newPointerPosition = new Vector2 (clampedX, clampedY);
        return newPointerPosition;
    }

    public void OnEndDrag (PointerEventData eventData) {
        //print("DragPanel: OnEndDrag: Running SavePanel()");
        // if (canvasSerialization != null)
        //     canvasSerialization.SaveCanvasPositions ();

        //LockInput (false);

        dragging = false;
    }

    // public void LockInput (bool v) {
    //     // if (!SimianNextLevelShit.activeShip)
    //     //     return;

    //     // ILockInput[] locks = SimianNextLevelShit.activeShip.GetComponentsInChildren<ILockInput> ();

    //     for (int i = 0; i < locks.Length; i++)
    //         locks[i].LockInput (v);
    // }
}