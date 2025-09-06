using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipManager : MonoBehaviour
{
    public GameObject tipPanel; // Panel that shows the full info
    public TMP_Text tipText; // Assign the TMP for info display
    public GameObject nextButton, backButton;

    private int currentIndex = 0;
    private string[] currentTipPages;

    public void ShowTip(string[] pages)
    {
        currentIndex = 0;
        currentTipPages = pages;
        tipPanel.SetActive(true);
        ShowPage();
    }

    public void NextPage()
    {
        if (currentIndex < currentTipPages.Length - 1)
        {
            currentIndex++;
            ShowPage();
        }
    }

    public void PreviousPage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            ShowPage();
        }
    }

    public void CloseTipPanel()
    {
        tipPanel.SetActive(false);
    }

    private void ShowPage()
    {
        tipText.text = currentTipPages[currentIndex];
        backButton.SetActive(currentIndex > 0);
        nextButton.SetActive(currentIndex < currentTipPages.Length - 1);
    }
}
