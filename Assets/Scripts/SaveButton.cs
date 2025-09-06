using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    public GameObject saveConfirmationPanel; // Assign in Inspector
    public Button backButton; // Assign in Inspector

    private void Start()
    {
        if (backButton != null)
            backButton.onClick.AddListener(CloseConfirmationPanel);

        if (saveConfirmationPanel != null)
            saveConfirmationPanel.SetActive(false);
    }


    public void OnSaveButtonClicked()
    {
        int slot = GameManager.Instance.activeSaveSlot;

        if (slot != -1)
        {
            SaveData data = new SaveData();
            data.playerName = GameManager.Instance.playerName;
            data.health = GameManager.Instance.health;
            data.diet = GameManager.Instance.diet;
            data.satiety = GameManager.Instance.satiety;
            data.lastScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

            data.coins = CoinManager.Instance.GetCoins(); // Save coin value


            SaveManager.SaveGame(slot, data);

            Debug.Log("Game saved to slot " + slot);

            if (saveConfirmationPanel != null)
                saveConfirmationPanel.SetActive(true); // Show panel
        }
        else
        {
            Debug.LogWarning("No save slot active!");
        }
    }

    private void CloseConfirmationPanel()
    {
        if (saveConfirmationPanel != null)
            saveConfirmationPanel.SetActive(false);
    }
}

