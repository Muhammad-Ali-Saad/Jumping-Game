using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // Singleton pattern
    public Text coinsText;  // Reference to the UI Text for displaying coins
    private int coinsCount = 0;  // Counter for coins

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCoinsText();  // Update the coins text when the game starts
    }
    public int GetCoinsCount()
    {
        return coinsCount;
    }

    public void CollectCoin()
    {
        coinsCount++;  // Increase the coins count
        UpdateCoinsText();  // Update the UI Text
    }

    void UpdateCoinsText()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + coinsCount.ToString();  // Update the UI Text
        }
    }
}
