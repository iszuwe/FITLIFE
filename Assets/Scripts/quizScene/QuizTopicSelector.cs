//using UnityEngine;
//using UnityEngine.UI;

//public class QuizTopicSelector : MonoBehaviour
//{
//    public Button[] topicButtons;         // Assign in Inspector
//    public string[] topicKeys;            // Match each topic with PlayerPrefs key
//    public GameObject quizPanel;
//    public GameObject topicSelectorPanel;

//    public QuizManager quizManager; // assign in inspector


//    void Start()
//    {

//        for (int i = 0; i < topicButtons.Length; i++)
//        {
//            int index = i;

//            bool unlocked = PlayerPrefs.GetInt(topicKeys[index], 0) == 1;
//            topicButtons[index].interactable = unlocked;

//            // Only add listener if unlocked
//            if (unlocked)
//            {
//                topicButtons[index].onClick.AddListener(() =>
//                {
//                    PlayerPrefs.SetString("SelectedTopic", topicKeys[index]);
//                    PlayerPrefs.Save();

//                    quizPanel.SetActive(true);
//                    topicSelectorPanel.SetActive(false);
//                    quizManager.StartQuiz();

//                    Debug.Log($"Button {index} ({topicKeys[index]}) unlocked: {unlocked}");

//                });
//            }
//        }
//    }
//}

using UnityEngine;
using UnityEngine.UI;

public class QuizTopicSelector : MonoBehaviour
{
    public Button[] topicButtons;   // Assign buttons in Inspector
    public string[] topicKeys;      // Assign matching topic keys in Inspector
    public GameObject quizPanel;
    public GameObject topicSelectorPanel;

    public QuizManager quizManager; // Assign in Inspector

    void Start()
    {
        int currentSlot = PlayerPrefs.GetInt("CurrentSlot", 0);

        for (int i = 0; i < topicButtons.Length; i++)
        {
            int index = i;
            Button button = topicButtons[i];
            string unlockKey = $"Slot{currentSlot}_{topicKeys[index]}";

            bool unlocked = PlayerPrefs.GetInt(unlockKey, 0) == 1;
            button.interactable = unlocked;

            button.onClick.AddListener(() =>
            {
                PlayerPrefs.SetString("SelectedTopic", topicKeys[index]);
                PlayerPrefs.Save();

                quizPanel.SetActive(true);
                topicSelectorPanel.SetActive(false);
                quizManager.StartQuiz();
            });

        }
    }

}
