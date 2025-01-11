using UnityEngine;

public class Level2Manager : MonoBehaviour, ILevelManager
{
    [SerializeField] private ScoreManager scoreManager;  // Referencia al gestor de puntuación
    [SerializeField] private LifeManager lifeManager;    // Referencia al gestor de vidas
    public float timeRemaining = 60f; // 60 segundos para completar el nivel

    private bool levelCompleted = false;
    private bool isGameOver = false;

    private void Awake()
    {
        // Inicialización de referencias, si es necesario
    }

    public void StartLevel()
    {
        if (scoreManager == null || lifeManager == null)
        {
            Debug.LogError("ScoreManager o LifeManager no están inicializados. No se puede iniciar el nivel.");
            return;
        }

        // Restablece la puntuación y las vidas al comenzar el nivel
        scoreManager.ResetScore();
        lifeManager.ResetLives();
        timeRemaining = 60f; // Restablecer el temporizador
        isGameOver = false;
        levelCompleted = false;

        Debug.Log("Nivel 2 iniciado correctamente.");
    }

    public void UpdateLevel()
    {
        if (!levelCompleted && !isGameOver)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0 && !levelCompleted)
            {
                Debug.Log("Tiempo agotado. Alicia no ha encontrado la llave a tiempo.");
                GameOver();
            }
        }
    }

    public void EndLevel()
    {
        if (levelCompleted)
        {
            Debug.Log("Nivel 2 completado exitosamente. Alicia ha ganado.");
        }
        else
        {
            Debug.Log("Nivel 2 terminado sin completar los objetivos. Alicia ha perdido.");
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game over. Alicia ha perdido el juego.");
        EventManager.OnGameOver();
        EndLevel();
    }

    private void OnEnable()
    {
        EventManager.PlayerHitKey += HandlePlayerHitKey; // Suscripción al evento cuando Alicia toca la llave
    }

    private void OnDisable()
    {
        EventManager.PlayerHitKey -= HandlePlayerHitKey; // Desuscripción del evento
    }

    private void HandlePlayerHitKey()
    {
        if (!isGameOver)
        {
            Debug.Log("Alicia ha tocado la llave Key. ¡Nivel completado!");
            levelCompleted = true;
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Nivel completado. Llamando a EndLevel...");
        EventManager.OnLevelComplete();
        EndLevel();
    }
}
