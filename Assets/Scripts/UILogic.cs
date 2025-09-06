using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UILogic : MonoBehaviour
{
    public GameObject openPanel;
    public GameObject instructionPanel;
    public GameObject[] pages;
    public Button nextButton;
    public Button backButton;
    public Button skipButton;

    public string sceneToLoad;
    private string hasSeenInstructionsKey;
    public int saveSlot = 1; // Assign this based on current player slot

    private int currentPage = 0;

    void Start()
    {
        openPanel.SetActive(false);

        // Only show instructions if they haven't been seen this session
        if (GameManager.Instance != null && !GameManager.Instance.hasSeenInstructions)
        {
            ShowInstructions();
            GameManager.Instance.hasSeenInstructions = true;
        }
        else
        {
            instructionPanel.SetActive(false);
        }


        UpdatePage();
    }

    public void Onclickedbtn()
    {
        openPanel.SetActive(true);
    }
    public void Onclickedclosedbtn()
    {
        openPanel.SetActive(false);
    }
    public void TriggerSceneChange()
    {
       
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ShowInstructions()
    {
        instructionPanel.SetActive(true);
        currentPage = 0;
        UpdatePage();
    }

    public void HideInstructions()
    {
        instructionPanel.SetActive(false);
    }

    public void NextPage()
    {
        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            UpdatePage();
        }
        else
        {
            HideInstructions();
        }
    }

    public void BackPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdatePage();
        }
    }

    void UpdatePage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == currentPage);
        }

        backButton.interactable = currentPage > 0;
        nextButton.GetComponentInChildren<TMPro.TMP_Text>().text = (currentPage == pages.Length - 1) ? "Tutup" : ">";
    }

    public void SkipInstructions()
    {
        HideInstructions();
    }

}
