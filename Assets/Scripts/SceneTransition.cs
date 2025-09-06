using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject enterButtonUI; 

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange)
        {
            enterButtonUI.SetActive(true);
        }
        else
        {
            enterButtonUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInRange = false;
        }
    }

    public void TriggerSceneChange()
    {
        playerStorage.initialValue = playerPosition;
        SceneManager.LoadScene(sceneToLoad);
    }
}
