using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class FoodMenuManager : MonoBehaviour
{
    public GameObject foodPanel;
    public TextMeshProUGUI descriptionText;
    public Image foodIcon;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI dietText;
    public TextMeshProUGUI satietyText;
    public TextMeshProUGUI priceText; // Add in your UI and link in Inspector
    public TextMeshProUGUI coinWarningText; // Optional warning text
    public GameObject notEnoughCoinsPanel; // assign in Inspector


    public Button consumeButton;

    private FoodItem currentSelectedFood;

    public BarManager barManager; 

    private void Start()
    {
        if (consumeButton != null)
            consumeButton.onClick.AddListener(ConsumeFood);
        notEnoughCoinsPanel.SetActive(false);
    }

    public void OpenFoodPanel()
    {
        if (foodPanel != null)
            foodPanel.SetActive(true);
    }

    public void CloseFoodPanel()
    {
        if (foodPanel != null)
            foodPanel.SetActive(false);
    }

    public void ShowFoodDetails(FoodItem item)
    {
        currentSelectedFood = item;

        if (item != null)
        {
            descriptionText.text = item.description;
            foodIcon.sprite = item.icon;
            healthText.text = "Health: " + item.healthValue;
            dietText.text = "Diet: " + item.dietValue;
            satietyText.text = "Satiety: " + item.satietyValue;
            priceText.text = "Price: " + item.price + " coins";

            coinWarningText.text = ""; 
        }
    }

    public void ConsumeFood()
    {
        if (currentSelectedFood != null && barManager != null)
        {
            int price = currentSelectedFood.price;
            if (CoinManager.Instance.SpendCoins(price))
            {
                barManager.AdjustBars(
                    currentSelectedFood.healthValue,
                    currentSelectedFood.dietValue,
                    currentSelectedFood.satietyValue
                );

                UnityEngine.Debug.Log("Consumed: " + currentSelectedFood.foodName);
                coinWarningText.text = "";
            }
            else
            {
                UnityEngine.Debug.Log("Not enough coins to buy " + currentSelectedFood.foodName);
                notEnoughCoinsPanel.SetActive(true);
            }
        }
    }

    public void CloseNotEnoughCoinsPanel()
    {
        notEnoughCoinsPanel.SetActive(false);
    }

}
