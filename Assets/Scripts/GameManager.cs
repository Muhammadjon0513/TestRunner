using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive = false;
    
    private PlayerController player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
        // O'yin boshlanganda UI'ni Start holatiga keltiramiz
        if (UIManager.Instance != null) UIManager.Instance.ShowStartScreen();
    }

    public void StartGame()
    {
        isGameActive = true;
        if (player != null) player.StartGame();
        if (UIManager.Instance != null) UIManager.Instance.ShowGameScreen();
    }

    public void GameOver()
    {
        isGameActive = false;
        if (player != null) player.EndGame();
        if (UIManager.Instance != null) UIManager.Instance.ShowLoseScreen();
    }

    public void LevelComplete()
    {
        isGameActive = false;
        if (player != null) player.EndGame();
        if (UIManager.Instance != null) UIManager.Instance.ShowWinScreen();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        // Keyingi levelga o'tish (yoki aylantirib qayta boshlash)
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
