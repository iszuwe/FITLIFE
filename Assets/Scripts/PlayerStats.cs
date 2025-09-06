using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth;
    public int currentDiet;
    public int currentSatiety;

    public void ApplyFood(FoodItem food)
    {
        currentHealth += food.healthValue;
        currentDiet += food.dietValue;
        currentSatiety += food.satietyValue;

        // Optional: clamp max values or trigger animations/effects
        UnityEngine.Debug.Log($"Applied {food.foodName}: +{food.healthValue} HP, +{food.dietValue} Diet, +{food.satietyValue} Satiety");
    }
}
