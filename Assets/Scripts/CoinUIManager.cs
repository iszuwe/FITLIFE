using TMPro;
using UnityEngine;

public class CoinUIManager : MonoBehaviour
{
    public static CoinUIManager Instance;
    public TextMeshProUGUI coinText;

    //void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject); // Persist across scenes
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void Update()
    {
        if (coinText != null && CoinManager.Instance != null)
        {
            coinText.text = "" + CoinManager.Instance.GetCoins();
        }
    }
}
