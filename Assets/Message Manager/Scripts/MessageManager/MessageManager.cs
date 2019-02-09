using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour {
    private static MessageManager displayManager;
    
    public GameObject msgPrefabImage;
    public GameObject msgPrefabNoImage;
    public RectTransform contentPanel;

    public float displayTime;
    public float fadeTime;
    public Text worldText;

    private IEnumerator fadeAlpha;
    
    //This could be folded into a compiler directive or set manually.
    [SerializeField] private bool showDebugMessages;

    public static MessageManager Instance () {
        if (!displayManager) {
            displayManager = FindObjectOfType (typeof (MessageManager)) as MessageManager;
            if (!displayManager)
                Debug.LogError ("There needs to be one active DisplayManager script on a GameObject in your scene.");
        }

        return displayManager;
    }

    internal void RemoveMessage (MessageManagerEntry displayManagerEntry) {
        float heightAdjust = displayManagerEntry.GetComponent<RectTransform> ().sizeDelta.y;
        Vector2 adjustDelta = contentPanel.sizeDelta;
        adjustDelta.y -= (heightAdjust + 4f);
        contentPanel.sizeDelta = adjustDelta;

        Destroy(displayManagerEntry.gameObject);
    }

    public void DisplayMessage (string message, Color color, float removeWait = 120f, Sprite sprite = null, bool isDebugMessage = false) {
        if (isDebugMessage && !showDebugMessages)
            return;

        GameObject entry = null;
        if (sprite == null)
            entry = Instantiate (msgPrefabNoImage, contentPanel);
        else
            entry = Instantiate (msgPrefabImage, contentPanel);

        //entry.GetComponent<RectTransform> ().SetAsFirstSibling ();
        entry.GetComponent<RectTransform> ().SetAsLastSibling ();

        MessageManagerEntry dme = entry.GetComponent<MessageManagerEntry> ();
        dme.SetEntry (message, color, sprite);

        Vector2 contentSize = contentPanel.sizeDelta;
        contentSize.y += entry.GetComponent<RectTransform> ().sizeDelta.y + 4f;
        contentPanel.sizeDelta = contentSize;

        dme.TimedRemoveMessage(removeWait);
    }
}