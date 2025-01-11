using UnityEngine;

public class Level3Manager : MonoBehaviour, ILevelManager
{
    private ScoreManager scoreManager;
    private LifeManager lifeManager;
    public int lives;
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


    public void InitializeLifeManager(LifeManager lifeManager)
    {
        this.lifeManager = lifeManager;
        if (this.lifeManager == null)
        {

            Debug.LogError("lifeManager no inicializado en Level3Manager.");
        }
        else
        {
            Debug.Log("lifeManager inicializado correctamente en Level3Manager.");

        }
    }

    public void StartLevel()
    {
        if (scoreManager == null || lifeManager == null)
        {
            Debug.LogError("scoreManager o lifeManager no están inicializados. No se puede iniciar el nivel.");
            return;
        }

        scoreManager.ResetScore();
        lifeManager.ResetLives();
        isGameOver = false;

        Debug.Log(isGameOver);

        levelCompleted = false;

        Debug.Log("Nivel 3 iniciado correctamente.");
    }
    public void UpdateLevel()
    {
        if (!levelCompleted && !isGameOver)
        {
            if (scoreManager.CurrentScore >= 1)
                {
                CompleteLevel();
                }
        }

    }
    public void EndLevel()
    {
        Debug.Log("Nivel 1 terminado.");
        EventManager.OnLevelComplete();
    }

    private void OnDisable()
    {

        EventManager.PlayerHitKey -= HandlePlayerHitKey;
        EventManager.PlayerAttacked -= HandlePlayerAttacked;
    }

    private void OnEnable()
    {

        EventManager.PlayerHitKey += HandlePlayerHitKey;

        EventManager.PlayerAttacked += HandlePlayerAttacked;
    
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

    private void HandlePlayerAttacked()
    {
        
            if (!isGameOver && lifeManager != null)
            {
                Debug.Log("Jugador atacado en Nivel 3. Eliminando todas las vidas.");
                lifeManager.ResetLivesToZero(); 
                GameOver();
            }
        
    }
    private void HandlePlayerHitKey()
    {
        if (scoreManager != null)
        {
            Debug.Log("El jugador ha colisionado con un Teapot.");
            scoreManager.AddPoints(1);
        }

    }
}
