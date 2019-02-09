using UnityEngine;
using System.Collections;

public class KeepOnLoad : MonoBehaviour {

    void Awake()
    {
        //Debug.Log("Canvas Load");
        DontDestroyOnLoad(this);
    }
}
