﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StandaloneInputModuleCustom : StandaloneInputModule
{

    public PointerEventData GetLastPointerEventDataPublic(int id)
    {
        return GetLastPointerEventData(id);
    }
}