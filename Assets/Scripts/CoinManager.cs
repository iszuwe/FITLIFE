using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int coins = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            return true;
        }
        return false;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public int GetCoins()
    {
        return coins;
    }
}
