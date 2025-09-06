//using System.Diagnostics;
//using UnityEngine;

//public class TopicUnlocker : MonoBehaviour
//{
//    [Tooltip("The key to unlock this topic, e.g., 'PanduanMakan'")]
//    public string topicKey;

//    public void UnlockTopic()
//    {
//        PlayerPrefs.SetInt(topicKey, 1);
//        PlayerPrefs.Save();
//        Debug.Log("Topic Unlocked: " + topicKey);
//    }
//}
using UnityEngine;

public class TopicUnlocker : MonoBehaviour
{
    public string topicKey; // E.g., "Topic_panduanmakanan"

    public void UnlockTopic()
    {
        int currentSlot = PlayerPrefs.GetInt("CurrentSlot", -1);

        if (currentSlot == -1)
        {
            Debug.LogError("CurrentSlot is not set! Cannot unlock topic.");
            return;
        }

        string unlockKey = $"Slot{currentSlot}_{topicKey}";

        PlayerPrefs.SetInt(unlockKey, 1);
        PlayerPrefs.Save();

        Debug.Log($"Unlocked topic for slot {currentSlot}: {unlockKey}");
    }

}
