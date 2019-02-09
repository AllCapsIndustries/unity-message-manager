using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class ModalPanel : MonoBehaviour
{
    public Text question;
    public Image iconImage;
    public Button yesButton;
    public Button noButton;
    public Button applyButton;
    public Button cancelButton;
    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return modalPanel;
    }

    // Yes/No/Cancel: A string, a Yes event, a No event and Cancel event
    public void Choice(string question, UnityAction yesEvent, UnityAction cancelEvent, UnityAction noEvent, UnityAction applyEvent)
    {
        modalPanelObject.SetActive(true);

        if (yesButton != null && yesEvent != null)
        {
            yesButton.onClick.RemoveAllListeners();
            if (yesEvent != null)
                yesButton.onClick.AddListener(yesEvent);

            yesButton.onClick.AddListener(ClosePanel);

            yesButton.gameObject.SetActive(true);
        }

        if (noButton != null && noEvent != null)
        {
            noButton.onClick.RemoveAllListeners();
            if (noEvent != null)
                noButton.onClick.AddListener(noEvent);

            noButton.onClick.AddListener(ClosePanel);

            noButton.gameObject.SetActive(true);
        }

        if (applyButton != null && applyEvent != null)
        {
            applyButton.onClick.RemoveAllListeners();
            if (applyEvent != null)
                applyButton.onClick.AddListener(applyEvent);

            //applyButton.onClick.AddListener(ClosePanel);

            applyButton.gameObject.SetActive(true);
        }

        if (cancelButton != null && cancelEvent != null)
        {
            cancelButton.onClick.RemoveAllListeners();
            if (cancelEvent != null)
                cancelButton.onClick.AddListener(cancelEvent);

            cancelButton.onClick.AddListener(ClosePanel);

            cancelButton.gameObject.SetActive(true);
        }

        if (!string.IsNullOrEmpty(question))
        {
            this.question.text = question;
        }

        if (iconImage != null)
        {
            this.iconImage.gameObject.SetActive(false);
        }
    }

    void ClosePanel()
    {
        modalPanelObject.SetActive(false);
    }
}