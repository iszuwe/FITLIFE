using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipButtons : MonoBehaviour
{
    public TipManager tipManager;

    public void OnClickTip1()
    {
        string[] tipPages = {
            "Tip 1: Eat a variety of foods in your daily meals.",
            "Mix grains, vegetables, proteins, and fruits."
        };
        tipManager.ShowTip(tipPages);
    }

    public void OnClickTip2()
    {
        string[] tipPages = {
            "Tip 2: Maintain a healthy body weight.",
            "Balance your food intake with regular physical activity."
        };
        tipManager.ShowTip(tipPages);
    }

    // Add more tips (up to 7) in similar format
}

