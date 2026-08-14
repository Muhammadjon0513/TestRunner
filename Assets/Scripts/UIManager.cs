using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panels")]
    public GameObject startScreen;
    public GameObject gameScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    [Header("UI Elements")]
    public TextMeshProUGUI levelText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Tepada Level nechiligini ko'rsatib turish uchun
        if (levelText != null)
        {
            int currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
            levelText.text = "Level " + currentLevel;
        }
    }

    public void ShowStartScreen()
    {
        if(startScreen) startScreen.SetActive(true);
        if(gameScreen) gameScreen.SetActive(false);
        if(winScreen) winScreen.SetActive(false);
        if(loseScreen) loseScreen.SetActive(false);
    }

    public void ShowGameScreen()
    {
        if(startScreen) startScreen.SetActive(false);
        if(gameScreen) gameScreen.SetActive(true);
        if(winScreen) winScreen.SetActive(false);
        if(loseScreen) loseScreen.SetActive(false);
    }

    public void ShowWinScreen()
    {
        if(gameScreen) gameScreen.SetActive(false);
        if(winScreen) winScreen.SetActive(true);
    }

    public void ShowLoseScreen()
    {
        if(gameScreen) gameScreen.SetActive(false);
        if(loseScreen) loseScreen.SetActive(true);
    }

    // UI Button'lar orqali chaqiriladigan metodlar
    public void Button_StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void Button_NextLevel()
    {
        GameManager.Instance.NextLevel();
    }

    public void Button_Restart()
    {
        GameManager.Instance.RestartLevel();
    }
}
