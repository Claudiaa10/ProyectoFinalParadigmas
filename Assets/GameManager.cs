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
        if (gameOverScreen != null)
        {
            gameOverScreen.gameObject.SetActive(false); // Asegúrate de que el Canvas esté desactivado al inicio
        }
    }
    public void GameOver()
    {
        Debug.Log("¡Game Over!");
        if (gameOverScreen != null)
        {
            gameOverScreen.Setup(points); // Llama a Setup para mostrar la pantalla de Game Over con los puntos
        }
    }

        public void AddLife()
    {
        lives++;
        Debug.Log($"Vidas restantes: {lives}");
    }

    public void AddPoint()
    {
        points++;
        Debug.Log($"Puntos: {points}");
    }
   
    public void RemoveLife()
    {
        lives --;
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
    }

    private void OnDisable()
    {
        EventManager.PlayerHitHat -= HandlePlayerHitHat;
        EventManager.PlayerHitTeapot -= HandlePlayerHitTeapot;
    }

    private void HandlePlayerHitHat()
    {
        Debug.Log("El jugador ha colisionado con un Hat.");
        RemoveLife();
    }

    private void HandlePlayerHitTeapot()
    {
        Debug.Log("El jugador ha colisionado con un Teapot.");
        AddLife();
    }

    private void HandlePlayerDodgeHat()
    {
        Debug.Log("El jugador ha esquivado el sombrero.");
        AddPoint();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

