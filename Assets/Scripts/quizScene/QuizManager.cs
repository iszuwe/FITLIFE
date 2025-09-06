using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [Header("Quiz Topic Data")]
    public QuizTopicData[] allTopics;             // ScriptableObjects for all topics
    private QuizQuestion[] selectedQuestions;     // Questions from selected topic
    private int currentQuestion = 0;

    [Header("Scene Management")]
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    [Header("UI Elements")]
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public Button closeFeedbackBtn;
    public GameObject quizPanel;
    public GameObject feedbackPanel;
    public GameObject rewardPanel;
    public TextMeshProUGUI rewardText;
    public GameObject outdoorSceneBtn;

    private bool answeredCorrectly = false;
    private int correctAnswerCount = 0;

    public void StartQuiz()
    {
        string selectedTopic = PlayerPrefs.GetString("SelectedTopic", "");

        if (string.IsNullOrEmpty(selectedTopic))
        {
            Debug.LogError("No topic selected. Returning to topic selection screen.");
            // Optionally re-enable topic selection panel here
            return;
        }

        foreach (var topic in allTopics)
        {
            if (topic.topicKey == selectedTopic)
            {
                selectedQuestions = topic.questions;
                break;
            }
        }

        currentQuestion = 0;
        ShowQuestion();
    }

    void ShowQuestion()
    {
        QuizQuestion q = selectedQuestions[currentQuestion];
        questionText.text = q.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerClick(index));
        }
    }

    void OnAnswerClick(int selectedIndex)
    {
        QuizQuestion q = selectedQuestions[currentQuestion];
        answeredCorrectly = selectedIndex == q.correctAnswerIndex;

        feedbackPanel.SetActive(true);
        feedbackPanel.GetComponentInChildren<TextMeshProUGUI>().text =
            answeredCorrectly ? "TAHNIAH ANDA BETUL!!!" : "Maaf, jawapan salah.";

        foreach (Button btn in answerButtons)
            btn.interactable = false;

        if (answeredCorrectly)
        {
            correctAnswerCount++;
        }

        outdoorSceneBtn.SetActive(false);
    }

    public void CloseFeedback()
    {
        feedbackPanel.SetActive(false);
        currentQuestion++;

        if (currentQuestion < selectedQuestions.Length)
        {
            ShowQuestion();

            foreach (Button btn in answerButtons)
                btn.interactable = true;
        }
        else
        {
            // Quiz ended
            quizPanel.SetActive(false);

            int coinsEarned = correctAnswerCount * 5;
            int totalCoins = PlayerPrefs.GetInt("Coins", 0) + coinsEarned;
            PlayerPrefs.SetInt("Coins", totalCoins);

            rewardText.text = $"Tahniah! Anda telah mendapat {coinsEarned} syiling.";
            rewardPanel.SetActive(true);
            outdoorSceneBtn.SetActive(true);

            CoinManager.Instance.AddCoins(coinsEarned);

          

        }
    }

    public void ExitToOutdoor()
    {
        playerStorage.initialValue = playerPosition;
        SceneManager.LoadScene(sceneToLoad);
    }
}
