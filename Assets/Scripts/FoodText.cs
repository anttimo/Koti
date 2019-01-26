﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodText : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"Food: {GameController.instance.FoodCount}";
    }
}
