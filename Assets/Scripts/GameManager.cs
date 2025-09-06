using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool hasSeenInstructions = false;


    public string playerName;

    public int activeSaveSlot = -1;


    public float health = 100f;
    public float diet = 50f;
    public float satiety = 100f;

    public int coins = 0; // Add this line


    public void StartNewGame(string name)
    {
        playerName = name;
        health = 100f;
        diet = 50f;
        satiety = 100f;
        hasSeenInstructions = false; // Reset for new game

        coins = coins;
    } 
    
    
    public void LoadFromSave(SaveData data)
    {
        playerName = data.playerName;
        health = data.health;
        diet = data.diet;
        satiety = data.satiety;
        hasSeenInstructions = false;

        CoinManager.Instance.coins = data.coins; //Load the saved coins
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
}