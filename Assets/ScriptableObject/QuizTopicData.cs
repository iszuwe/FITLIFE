using UnityEngine;

[CreateAssetMenu(fileName = "NewQuizTopic", menuName = "Quiz/Topic")]
public class QuizTopicData : ScriptableObject
{
    public string topicKey;  //Add this line
    public string topicName;
    public QuizQuestion[] questions;
}
