using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DietitianNPC : MonoBehaviour
{
    public GameObject panel;             // Parent panel (like Healthy Living Tips)
    public DietitianTipsUI tipsUI;       // Reference to the UI Manager script

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (panel != null) panel.SetActive(true);
            if (tipsUI != null) tipsUI.ShowTipsPanel();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (panel != null) panel.SetActive(false);
            if (tipsUI != null) tipsUI.HideAll();
        }

    }

    public void closeNPC()
    {
        panel.SetActive(false);
    }
}
