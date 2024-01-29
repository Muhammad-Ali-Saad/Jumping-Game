using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Add this line
    public GameObject gameOverPanel;
    public Text coinsText;
    public Button restartButton;

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
    // Disable the game over panel and restart button at the start
    if (gameOverPanel != null)
    {
        gameOverPanel.SetActive(false);
    }

    if (restartButton != null)
    {
        restartButton.gameObject.SetActive(false);
    }
}


    public void ShowGameOverPanel(int coinsCollected)
{
    // Show the game over panel
    if (gameOverPanel != null)
    {
        gameOverPanel.SetActive(true);

        // Update the coins text in the game over panel
        if (coinsText != null)
        {
            coinsText.text =coinsCollected.ToString();
        }

        // Enable the restart button
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
        }
    }
}
    public void RestartGame()
    {
        // Reload the current scene (assuming it's the main gameplay scene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
