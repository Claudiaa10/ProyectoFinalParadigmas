using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI livesText;

    [Header("Panels")]
    public GameOverScreen gameOverScreen;
    public LevelCompleteScreen levelCompleteScreen;
    public TextMeshProUGUI gameOverScoreText;

    private void Start()
    {
        if (livesText == null)
        {
            livesText = FindObjectOfType<TextMeshProUGUI>();
            Debug.LogWarning("LivesText no estaba asignado. Se buscó en la escena.");
        }

        if (gameOverScreen == null)
        {
            gameOverScreen = FindObjectOfType<GameOverScreen>();
            Debug.LogWarning("GameOverScreen no estaba asignado. Se buscó en la escena.");
        }

        if (levelCompleteScreen == null)
        {
            levelCompleteScreen = FindObjectOfType<LevelCompleteScreen>();
            Debug.LogWarning("LevelCompleteScreen no estaba asignado. Se buscó en la escena.");
        }

        if (gameOverScreen != null) {
            HideGameOverPanel();
        }
        if (levelCompleteScreen != null) 
        { HideLevelCompletePanel(); }
    }


    // Actualiza el texto de las vidas en pantalla
    public void UpdateLives(int lives)
    {
        if (livesText != null)
        {
            livesText.text = $"Lives: {lives}";
        }
    }

    // Muestra el panel de Game Over y actualiza la puntuación final
    public void ShowGameOverPanel(int finalScore)

    {
        Time.timeScale = 0;
        if (gameOverScreen != null)
        {
            gameOverScreen.Setup(finalScore);

        }
    }

    // Oculta el panel de Game Over
    public void HideGameOverPanel()
    {
        Debug.Log("ocultando pantalla");
        if (gameOverScreen != null)
        {
            gameOverScreen.gameObject.SetActive(false);
        }
    }

    // Muestra el panel de nivel completado
    public void ShowLevelCompletePanel(string level)
    {
        Time.timeScale = 0;
        if (levelCompleteScreen != null)
        {
            levelCompleteScreen.Setup(level);
        }
    }

    // Oculta el panel de nivel completado
    public void HideLevelCompletePanel()
    {
        Debug.Log("ocultando pantalla");
        if (levelCompleteScreen != null)
        {
            levelCompleteScreen.gameObject.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Reanuda el juego
    }



}
