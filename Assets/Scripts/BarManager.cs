using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider dietBar;
    public Slider satietyBar;
    
    [Range(0, 100)] public float health = 100f;
    [Range(0, 100)] public float diet = 50f;
    [Range(0, 100)] public float satiety = 100f;

    public float dietDecayRate = 1f; // diet drops over time
    public float hungerDecayRate = 3f; // Satiety drops over time

    private bool hasShownHungerWarning = false;
    private bool hasShownSatietyWarning = false;
    private bool hasShownHealthWarning = false;
    private bool hasShownDietWarning = false;

    private void Start()
    {
        // Load values from GameManager if available
        if (GameManager.Instance != null)
        {
            health = GameManager.Instance.health;
            diet = GameManager.Instance.diet;
            satiety = GameManager.Instance.satiety;
        }

        UpdateBars();
    }

    private void Update()
    {
       
        // Satiety decreases over time
        satiety -= hungerDecayRate * Time.deltaTime;
        satiety = Mathf.Clamp(satiety, 0, 100);

        // Diet decays slowly over time if not maintained
        diet -= dietDecayRate * Time.deltaTime;
        diet = Mathf.Clamp(diet, 0, 100);

        // If satiety is too low, health drops based on how bad the diet is
        if (satiety <= 20)
        {
            float dietModifier = 1f + ((100f - diet) / 100f); // Worse diet = faster health loss
            health -= 0.1f * dietModifier * Time.deltaTime;
        }

        // If diet is too low, health drops based on how bad the diet is
        if (diet <= 20)
        {
            float dietModifier = 1f + ((100f - diet) / 100f); // Worse diet = faster health loss
            health -= 0.1f * dietModifier * Time.deltaTime;
        }

        // If diet is high, health increase based on how good the diet is
        if (diet >= 50)
        {
            float dietModifier = 1f + ((100f - diet) / 100f); // good diet = health increase
            health += 1f * dietModifier * Time.deltaTime;
        }

        health = Mathf.Clamp(health, 0, 100);

        UpdateBars();

        // Save to GameManager if it's being used
        if (GameManager.Instance != null)
        {
            GameManager.Instance.health = health;
            GameManager.Instance.diet = diet;
            GameManager.Instance.satiety = satiety;
        }

        List<string> warnings = new List<string>();

        if (satiety <= 10f && !hasShownSatietyWarning)
        {
            warnings.Add("Awak kelaparan! Makan sesuatu segera!");
            hasShownSatietyWarning = true;
        }
        else if (satiety > 10f)
        {
            hasShownSatietyWarning = false;
        }

        if (health <= 10f && !hasShownHealthWarning)
        {
            warnings.Add("Anda terlalu lemah untuk terus bermain...");
            hasShownHealthWarning = true;
        }
        else if (health > 10f)
        {
            hasShownHealthWarning = false;
        }

        if (diet <= 10f && !hasShownDietWarning)
        {
            warnings.Add("Diet anda berkurangan. Makan makanan yang lebih sihat! atau bersenam");
            hasShownDietWarning = true;
        }
        else if (diet > 10f)
        {
            hasShownDietWarning = false;
        }

        if (warnings.Count > 0)
        {
            DialogueBox.Instance.ShowDialogueQueue(warnings);
        }

        
    }

    private void UpdateBars()
    {
        healthBar.value = health;
        dietBar.value = diet;
        satietyBar.value = satiety;
    }

    // These can be called from UI buttons or triggers
    public void EatHealthyFood()
    {
        satiety += 3f;
        diet += 10f;
        health += 0.1f;
        ClampAll();
    }

    public void EatJunkFood()
    {
        satiety += 14f;
        diet -= 10f;
        health -= 0.1f;
        ClampAll();
    }

    public void Exercise()
    {
        health += 10f;
        diet += 5f;
        satiety -= 5f;
        ClampAll();
    }

    private void ClampAll()
    {
        health = Mathf.Clamp(health, 0, 100);
        diet = Mathf.Clamp(diet, 0, 100);
        satiety = Mathf.Clamp(satiety, 0, 100);
        UpdateBars();
    }

    public void AdjustBars(float healthDelta, float dietDelta, float hungerDelta)
    {
        health += healthDelta;
        diet += dietDelta;
        satiety += hungerDelta;
        ClampAll();
    }

}