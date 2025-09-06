using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerBtn : MonoBehaviour
{
    public GameObject enterButtonUI;

    private bool playerInRange = false;

    // Update is called once per frame
    void Update()
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
}
