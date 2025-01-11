using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private ILevelManager currentLevelManager;
    private ScoreManager scoreManager;
    private LifeManager lifeManager;
    private UIManager uiManager;

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
        scoreManager = FindObjectOfType<ScoreManager>();
        lifeManager = FindObjectOfType<LifeManager>();
        uiManager = FindObjectOfType<UIManager>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        LoadScene("MainMenu");
    }

    private void OnEnable()
    {
        EventManager.LevelComplete += HandleLevelComplete;
        EventManager.RestartGame += RestartGame;
        EventManager.LifeChanged += HandleLifeChanged;
        EventManager.GameOver += HandleGameOver;
        EventManager.NextLevel += HandleNextLevel;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnDisable()
    {
        EventManager.LevelComplete -= HandleLevelComplete;
        EventManager.RestartGame -= RestartGame;
        EventManager.LifeChanged -= HandleLifeChanged;

        SceneManager.sceneLoaded -= OnSceneLoaded;
        EventManager.GameOver -= HandleGameOver;
        EventManager.NextLevel -= HandleNextLevel;
    }

    private void HandleGameOver()
    {
        Debug.Log("HandleGameOver llamado. Mostrando pantalla de Game Over...");

       
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }

        if (uiManager != null)
        {
            
            int finalScore = scoreManager?.CurrentScore ?? 0;
            uiManager.ShowGameOverPanel(finalScore);
        }
        else
        {
            Debug.LogError("UIManager no encontrado. No se puede mostrar el Game Over.");
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Escena cargada: {scene.name}");
        uiManager = FindObjectOfType<UIManager>();
        uiManager?.HideLevelCompletePanel();
        uiManager?.HideGameOverPanel();
        InitializeLevel();
    }

    private void InitializeLevel()

    {
        Time.timeScale = 1;
        GameObject levelManagerObject = GameObject.FindWithTag("LevelManager");

        if (levelManagerObject != null && levelManagerObject.GetComponent<ILevelManager>() is ILevelManager levelManager)
        {
            currentLevelManager = levelManager;

            if (currentLevelManager is Level1Manager level1Manager)
            {
                level1Manager.InitializeScoreManager(scoreManager);
                level1Manager.InitializeLifeManager(lifeManager);
            }

            else if (currentLevelManager is Level2Manager level2Manager)
            {
                level2Manager.InitializeScoreManager(scoreManager);
                level2Manager.InitializeLifeManager(lifeManager);
            }

            else if (currentLevelManager is Level3Manager level3Manager)
            {
                level3Manager.InitializeScoreManager(scoreManager);
                level3Manager.InitializeLifeManager(lifeManager);
            }

            currentLevelManager.StartLevel();
        }
        else
        {
            Debug.LogError("No se encontró un LevelManager con el tag 'LevelManager'.");
        }
    }


    public void HandleNextLevel()
    {
        Debug.Log("Continuando al siguiente nivel...");

    
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }
        uiManager?.HideLevelCompletePanel();
        uiManager?.HideGameOverPanel();
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        int nextSceneIndex = currentSceneIndex + 1; 

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {   
            currentSceneIndex = nextSceneIndex; 
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            Debug.Log("No hay más niveles. Reiniciando el juego...");
            RestartGame();
        }
    }

    private void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentSceneIndex);
        Debug.Log("Reiniciando el juego...");
        uiManager?.HideGameOverPanel();
        uiManager?.ResumeGame();
        scoreManager?.ResetScore();
        lifeManager?.ResetLives();
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void HandleLifeChanged(int remainingLives)
    {
        Debug.Log($"Vidas restantes: {remainingLives}");
        uiManager?.UpdateLives(remainingLives);

        if (remainingLives <= 0)
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        Debug.Log("Game Over.");
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            int finalScore = scoreManager.CurrentScore;
            uiManager.ShowGameOverPanel(finalScore);
        }
    }

    private void HandleLevelComplete()
    {
        Debug.Log("Nivel completado.");
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            string levelName = SceneManager.GetActiveScene().name;

            uiManager.ShowLevelCompletePanel(levelName);
        }
    }
}

