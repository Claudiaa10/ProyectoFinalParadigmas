using UnityEngine;

public class Level1Manager : MonoBehaviour, ILevelManager
{
    private ScoreManager scoreManager;
    private LifeManager lifeManager;
    public int lives;
    public float timeRemaining = 20f;
    private bool levelCompleted = false;
    private bool isGameOver = false;


    public void InitializeScoreManager(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    private void Update()
    {
        UpdateLevel();
    }

    private void UpdateTimer()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
           CompleteLevel();
            
        }
    }
    public void InitializeLifeManager(LifeManager lifeManager)
    {
        this.lifeManager = lifeManager;
        if (this.lifeManager == null)
        {
            Debug.LogError("lifeManager no inicializado en Level1Manager.");
        }
        else
        {
            Debug.Log("lifeManager inicializado correctamente en Level1Manager.");
        }
    }

    public void StartLevel()
    {
        scoreManager.ResetScore();
        lifeManager.ResetLives();
        timeRemaining = 20f;
        isGameOver = false;
        levelCompleted = false;
        //points = 0;
        //lives = 2;

    }

    public void UpdateLevel()
    {
        if (!levelCompleted && !isGameOver)
        {
            UpdateTimer();
        }

    }
    public void EndLevel()
    {
        Debug.Log("Nivel 1 terminado.");
        EventManager.OnLevelComplete();
    }

    private void OnDisable()
    {
        EventManager.PlayerHitHat -= HandlePlayerHitHat;
        EventManager.PlayerHitTeapot -= HandlePlayerHitTeapot;
    }

    private void OnEnable()
    {
        EventManager.PlayerHitHat += HandlePlayerHitHat;
        EventManager.PlayerHitTeapot += HandlePlayerHitTeapot;
    }


    private void CompleteLevel()
    {
        levelCompleted = true;
        Debug.Log("Nivel completado. Llamando a EndLevel...");
        EndLevel();
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game over");
        EventManager.OnGameOver();
    }

    private void HandlePlayerHitHat()
    {
        if (lifeManager != null)
        {
            Debug.Log("El jugador ha colisionado con un Hat.");
            lifeManager.RemoveLife();

        }
    }
    private void HandlePlayerHitTeapot()
    {
        if (scoreManager != null)
        {
            Debug.Log("El jugador ha colisionado con un Teapot.");
            scoreManager.AddPoints(1);
        }

    }
}
