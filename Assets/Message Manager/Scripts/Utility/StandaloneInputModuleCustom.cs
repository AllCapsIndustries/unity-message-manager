using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//NOTE: This probably isn't entirely necessary but it works well.
public class StandaloneInputModuleCustom : StandaloneInputModule
{
    public PointerEventData GetLastPointerEventDataPublic(int id)
    {
        return GetLastPointerEventData(id);
    }
}