using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameOverScreen gameOverScreen;
    private int world = 1;
    private int stage = 1;
    private int lives = 1;
    private int points = 0;

    private void Awake()
    {
        Debug.Log("GameManager inicializado.");
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        NewGame();
    }

    public void NewGame()
    {
        points = 0;
        lives = 1;
        Debug.Log("Iniciando nueva partida...");
        if (gameOverScreen != null)
        {
            Debug.Log($"Estado actual del Canvas GameOver: {gameOverScreen.gameObject.activeSelf}");
            gameOverScreen.gameObject.SetActive(false);
            Debug.Log($"Canvas GameOver desactivado: {gameOverScreen.gameObject.activeSelf}");
        }
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Debug.Log("¡Game Over!");
        Time.timeScale = 0;
        if (gameOverScreen != null)
        {
            gameOverScreen.Setup(points); // Llama a Setup para mostrar la pantalla de Game Over con los puntos
        }
    }

    public void AddPoint()
    {
        points++;
        Debug.Log($"Puntos: {points}");
    }

    public void RemoveLife()
    {
        lives--;
        Debug.Log($"Vidas restantes: {lives}");

        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void OnEnable()
    {
        EventManager.PlayerHitHat += HandlePlayerHitHat;
        EventManager.PlayerHitTeapot += HandlePlayerHitTeapot;
        EventManager.RestartGame += HandleRestart;
        Debug.Log("Suscrito a eventos en OnEnable.");
    }

    private void OnDisable()
    {
        EventManager.PlayerHitHat -= HandlePlayerHitHat;
        EventManager.PlayerHitTeapot -= HandlePlayerHitTeapot;
        EventManager.RestartGame -= HandleRestart;
    }

    private void HandleRestart()
    {
        Debug.Log("Restarting");
        RestartGame();
    }

    private void HandlePlayerHitHat()
    {
        Debug.Log("El jugador ha colisionado con un Hat.");
        RemoveLife();
    }

    private void HandlePlayerHitTeapot()
    {
        Debug.Log("El jugador ha colisionado con un Teapot.");
        AddPoint();
    }

    public void RestartGame()
    {
        Debug.Log("Reiniciando el juego...");
        Time.timeScale = 1;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Scene1");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        gameOverScreen = FindObjectOfType<GameOverScreen>();
        if (gameOverScreen != null)
        {
            Debug.Log("GameOverScreen reasignado correctamente.");
        }
        else
        {
            Debug.LogError("No se encontró un objeto GameOverScreen en la escena.");
        }
        NewGame();

        Debug.Log("Juego reiniciado correctamente.");
    }
}
