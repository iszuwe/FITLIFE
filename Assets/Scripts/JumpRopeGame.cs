using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JumpRopeGame : MonoBehaviour
{
    public Animator playerAnimator;
    public TextMeshProUGUI jumpCounterText; // Reference to the UI text
    public Button jumpButton;
    private int jumpCount = 0;

    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    void Update()
    {
        // Disable the jump button if satiety is zero
        if (GameManager.Instance != null && jumpButton != null)
        {
            jumpButton.interactable = GameManager.Instance.satiety > 0;
        }
    }

    public void OnJumpButtonClicked()
    {

        if (playerAnimator != null)
        {
            playerAnimator.SetTrigger("JumpTrigger");
            jumpCount++;
            UpdateJumpText();
        }
        else
        {
            Debug.LogError("Animator not assigned!");
        }
    }

    void UpdateJumpText()
    {
        if (jumpCounterText != null)
        {
            jumpCounterText.text = "" + jumpCount;
        }
    }

    public void TriggerSceneChange()
    {
        playerStorage.initialValue = playerPosition;
        SceneManager.LoadScene(sceneToLoad);
    }

 
}
