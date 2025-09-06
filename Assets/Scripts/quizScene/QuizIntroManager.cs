// Step 2: Quiz Intro Scene Manager
using UnityEngine;
using UnityEngine.UI;

public class QuizIntroManager : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject topicSelectionPanel;

    void Start()
    {
        introPanel.SetActive(true);
        topicSelectionPanel.SetActive(false);
    }

    public void OnContinueButtonPressed()
    {
        introPanel.SetActive(false);
        topicSelectionPanel.SetActive(true);
    }
}