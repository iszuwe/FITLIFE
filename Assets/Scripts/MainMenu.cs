using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject continuePanel;
    public TMP_InputField nameInputField;
    public GameObject nameInputPanel;
    public GameObject confirmDeletePanel;

    public Button slot1Button;
    public Button slot2Button;
    public Button slot3Button;

    private int selectedSlot = -1;
    private int slotToDelete = -1;

    void Start()
    {
        Debug.Log("Persistent Data Path: " + Application.persistentDataPath);

        // Hide panels on start
        continuePanel.SetActive(false);
        nameInputPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        UpdateSlotButtons();
    }

    public void OnNewGameClicked()
    {
        nameInputPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void ConfirmNewGame()
    {
        string playerName = nameInputField.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            selectedSlot = SaveManager.FindNextAvailableSlot();
            if (selectedSlot != -1)
            {
                PlayerPrefs.SetInt("CurrentSlot", selectedSlot);

                SaveManager.CreateNewSave(selectedSlot, playerName);
                
                SaveData data = SaveManager.LoadGame(selectedSlot);
                GameManager.Instance.LoadFromSave(data);
                SceneManager.LoadScene("OUTDOOR");

            }
            else
            {
                Debug.LogWarning("No available save slots.");
            }
        }
        else
        {
            Debug.LogWarning("Player name is empty.");
        }
    }

    private void UpdateSlotButtons()
    {
        slot1Button.interactable = SaveManager.SaveExists(1);
        slot2Button.interactable = SaveManager.SaveExists(2);
        slot3Button.interactable = SaveManager.SaveExists(3);

        UpdateSlotText(slot1Button, 1);
        UpdateSlotText(slot2Button, 2);
        UpdateSlotText(slot3Button, 3);
    }

    private void UpdateSlotText(Button button, int slot)
    {
        var textComponent = button.GetComponentInChildren<TMP_Text>();
        if (SaveManager.SaveExists(slot))
        {
            SaveData data = SaveManager.LoadGame(slot);
            textComponent.text = data.playerName;
        }
        else
        {
            textComponent.text = $"Empty Slot {slot}";
        }
    }

    public void LoadSlot(int slot)
    {
        if (SaveManager.SaveExists(slot))
        {
            PlayerPrefs.SetInt("CurrentSlot", slot); //Use the correct slot


            SaveData data = SaveManager.LoadGame(slot);
            GameManager.Instance.activeSaveSlot = slot;
            GameManager.Instance.LoadFromSave(data);
            SceneManager.LoadScene(data.lastScene); // Load the last scene from save
            CoinManager.Instance.coins = data.coins;

        }
        else
        {
            Debug.LogWarning($"No save found in slot {slot}");
        }
    }

    public void DeleteSlot(int slot)
    {
        PromptDeleteSlot(slot);

    }

    public void PromptDeleteSlot(int slot)
    {
        slotToDelete = slot;
        confirmDeletePanel.SetActive(true);
    }

    public void ConfirmDelete()
    {
        if (slotToDelete != -1)
        {
            string path = SaveManager.GetSavePath(slotToDelete);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                Debug.Log($"Deleted save slot {slotToDelete}");
            }
            slotToDelete = -1;
            confirmDeletePanel.SetActive(false);
            UpdateSlotButtons();
        }
    }

    public void OnContinueClicked()
    {
        UpdateSlotButtons();

        continuePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void CancelDelete()
    {
        slotToDelete = -1;
        confirmDeletePanel.SetActive(false);
    }


    public void BackToMain()
    {
        nameInputPanel.SetActive(false);
        continuePanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}

