using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodButton : MonoBehaviour
{
    public FoodItem foodData;
    public Button button;
    public FoodMenuManager menuManager;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        menuManager.ShowFoodDetails(foodData);
    }
}
