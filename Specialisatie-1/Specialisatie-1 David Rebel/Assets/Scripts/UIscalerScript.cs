﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscalerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
