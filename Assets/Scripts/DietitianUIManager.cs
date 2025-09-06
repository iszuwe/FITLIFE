using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DietitianUIManager : MonoBehaviour
{
    public GameObject tipsButtonPanel; // "Tips 7 button"
    public GameObject tipsInfoPanel;   // "Tips Panel"

    public TextMeshProUGUI tipsText;
    public string[] currentTipPages; // Stores text pages for a selected tip
    private int currentPage = 0;

    void Start()
    {
        // Ensure only tipsButtonPanel is visible at first
        tipsButtonPanel.SetActive(false);
        tipsInfoPanel.SetActive(false);
    }

    public void ShowTipsButtons()
    {
        tipsButtonPanel.SetActive(true);
        tipsInfoPanel.SetActive(false);
    }

    public void ShowTip(string[] tipPages)
    {
        currentTipPages = tipPages;
        currentPage = 0;
        UpdateTipText();

        tipsButtonPanel.SetActive(false);
        tipsInfoPanel.SetActive(true);
    }

    public void NextTip()
    {
        if (currentPage < currentTipPages.Length - 1)
        {
            currentPage++;
            UpdateTipText();
        }
    }

    public void PreviousTip()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdateTipText();
        }
    }

    public void CloseTip()
    {
        tipsInfoPanel.SetActive(false);
        tipsButtonPanel.SetActive(true);
    }

    void UpdateTipText()
    {
        tipsText.text = currentTipPages[currentPage];
    }
}

