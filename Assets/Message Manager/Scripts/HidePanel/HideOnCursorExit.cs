using UnityEngine;
using UnityEngine.UI;

public class HideOnCursorExit : MonoBehaviour
{
    //Assign these in Unity
    public Image[] hideImages;
    public Text[] hideText;
    private float[] _originalAlpha;

    void Start()
    {
        _originalAlpha = new float[hideImages.Length];
        for (int i = 0; i < hideImages.Length; i++)
        {
            _originalAlpha[i] = hideImages[i].color.a;

            Color hideColor = hideImages[i].color;
            hideColor.a = 0f;
            hideImages[i].color = hideColor;
        }

        for (int i = 0; i < hideText.Length; i++)
        {
            hideText[i].enabled = false;
        }

        Hide();
    }

    internal void Hide()
    {
        for (int i = 0; i < hideImages.Length; i++)
        {
            Color oColor = hideImages[i].color;
            oColor.a = 0f;

            hideImages[i].color = oColor;
        }

        for (int i = 0; i < hideText.Length; i++)
        {
            hideText[i].enabled = false;
        }
    }

    internal void UnHide()
    {
        for (int i = 0; i < hideImages.Length; i++)
        {
            Color oColor = hideImages[i].color;
            oColor.a = _originalAlpha[i];

            hideImages[i].color = oColor;
        }

        for (int i = 0; i < hideText.Length; i++)
        {
            hideText[i].enabled = true;
        }
    }
}
