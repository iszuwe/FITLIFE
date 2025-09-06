using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DietitianTipsUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject tipsButtonPanel;  // the panel with 7 buttons
    public GameObject tipContentPanel;  // the panel that shows info with next/back

    [Header("Text")]
    public TextMeshProUGUI tipText;

    [Header("Tips Content")]
    [TextArea(3, 10)] public string[] tip1;
    [TextArea(3, 10)] public string[] tip2;
    [TextArea(3, 10)] public string[] tip3;
    [TextArea(3, 10)] public string[] tip4;
    [TextArea(3, 10)] public string[] tip5;
    [TextArea(3, 10)] public string[] tip6;
    [TextArea(3, 10)] public string[] tip7;

    private string[] currentTip;
    private int currentPage = 0;

    //void Start()
    //{
    //    // Start with both hidden
    //    tipsButtonPanel.SetActive(false);
    //    tipContentPanel.SetActive(false);
    //}

    public void ShowTipsPanel()
    {
        tipsButtonPanel.SetActive(true);
        tipContentPanel.SetActive(false);
    }

    public void ShowTip(int tipIndex)
    {
        switch (tipIndex)
        {
            case 1: currentTip = tip1; break;
            case 2: currentTip = tip2; break;
            case 3: currentTip = tip3; break;
            case 4: currentTip = tip4; break;
            case 5: currentTip = tip5; break;
            case 6: currentTip = tip6; break;
            case 7: currentTip = tip7; break;
            default: currentTip = new string[] { "No tip found." }; break;
        }

        currentPage = 0;
        tipText.text = currentTip[currentPage];

        tipsButtonPanel.SetActive(false);
        tipContentPanel.SetActive(true);
    }

    public void NextPage()
    {
        if (currentPage < currentTip.Length - 1)
        {
            currentPage++;
            tipText.text = currentTip[currentPage];
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            tipText.text = currentTip[currentPage];
        }
    }

    public void CloseTip()
    {
        tipContentPanel.SetActive(false);
        tipsButtonPanel.SetActive(true);
    }

    public void HideAll()
    {
        tipsButtonPanel.SetActive(false);
        tipContentPanel.SetActive(false);
    }

}
