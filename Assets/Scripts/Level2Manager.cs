using UnityEngine;



public class Level2Manager : MonoBehaviour, ILevelManager
{
    private ScoreManager scoreManager;  
    private LifeManager lifeManager;    
    public float timeRemaining = 60f; 
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
                GameOver();

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
        if (scoreManager == null || lifeManager == null)
        {
            Debug.LogError("ScoreManager o LifeManager no están inicializados. No se puede iniciar el nivel.");
            return;
        }
        scoreManager.ResetScore();
        lifeManager.ResetLives();
        timeRemaining = 60f;
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
        EventManager.PlayerHitKey += HandlePlayerHitKey; 
    }

    private void OnDisable()
    {
        EventManager.PlayerHitKey -= HandlePlayerHitKey; 
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
