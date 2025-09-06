using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject newGamePanel;
    public GameObject continuePanel;
    public TMPro.TMP_InputField nameInput;
    
    public void StartNewGame(string playerName, int slot)
    {

        SaveData data = new SaveData()
        {
            playerName = playerName,
            health = 100,
            diet = 50,
            satiety = 100,
            coins = 5,
            lastScene = "OUTDOOR" 
        };

        SaveManager.SaveGame(slot, data);
        GameManager.Instance.LoadFromSave(data);

        PlayerPrefs.SetInt("CurrentSlot", slot);
        PlayerPrefs.Save();

        SceneManager.LoadScene(data.lastScene);
    }

    public void OnNewSlotClicked(int slot)
    {
        string name = nameInput.text;

        if (!string.IsNullOrEmpty(name))
        {
            StartNewGame(name, slot);
        }
        else
        {
            Debug.LogWarning("Player name is empty!");
        }
    }

    public void LoadGame(int slot)
    {
        SaveData data = SaveManager.LoadGame(slot);
        if (data != null)
        {
            GameManager.Instance.LoadFromSave(data);

            PlayerPrefs.SetInt("CurrentSlot", slot);
            PlayerPrefs.Save();

            SceneManager.LoadScene(data.lastScene);
        }
    }

    public void OnNewGameClicked()
    {
        newGamePanel.SetActive(true); // Show slot + name entry
    }

    public void OnCloseClicked()
    {
        newGamePanel.SetActive(false);
    }

    

    public void OnContinueClicked()
    {
        continuePanel.SetActive(true); // Show available save slots
    }

}
