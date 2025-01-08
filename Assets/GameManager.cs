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
        // Inicializar dependencias
        scoreManager = FindObjectOfType<ScoreManager>();
        lifeManager = FindObjectOfType<LifeManager>();
        uiManager = FindObjectOfType<UIManager>();

        // Suscribirse al evento de carga de escenas
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Iniciar el juego cargando el primer nivel
        LoadScene("Scene1");
    }

    private void OnEnable()
    {
        EventManager.LevelComplete += HandleLevelComplete;
        EventManager.RestartGame += RestartGame;
        EventManager.LifeChanged += HandleLifeChanged;
        EventManager.GameOver += HandleGameOver;
    }

    private void OnDisable()
    {
        EventManager.LevelComplete -= HandleLevelComplete;
        EventManager.RestartGame -= RestartGame;
        EventManager.LifeChanged -= HandleLifeChanged;

        SceneManager.sceneLoaded -= OnSceneLoaded;
        EventManager.GameOver -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        Debug.Log("HandleGameOver llamado. Mostrando pantalla de Game Over...");

        // Asegúrate de que el UIManager esté inicializado
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }

        if (uiManager != null)
        {
            // Obtén la puntuación final (opcional)
            int finalScore = scoreManager?.CurrentScore ?? 0;

            // Muestra la pantalla de Game Over
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
        InitializeLevel();
    }

    private void InitializeLevel()
    {
        GameObject levelManagerObject = GameObject.FindWithTag("LevelManager");
        Debug.Log("Hola");
        if (levelManagerObject != null && levelManagerObject.GetComponent<ILevelManager>() is ILevelManager levelManager)
        {
            Debug.Log("Adios");
            currentLevelManager = levelManager;

            if (currentLevelManager is Level1Manager level1Manager)
            {
                level1Manager.InitializeScoreManager(scoreManager);
                level1Manager.InitializeLifeManager(lifeManager);
            }

            currentLevelManager.StartLevel();
        }
        else
        {
            Debug.LogError("No se encontró un LevelManager con el tag 'LevelManager'.");
        }
    }



    public void ContinueToNextLevel()
    {
        Debug.Log("Continuando al siguiente nivel...");
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            LoadScene(SceneManager.GetSceneByBuildIndex(nextSceneIndex).name);
        }
        else
        {
            Debug.Log("No hay más niveles. Reiniciando el juego...");
            RestartGame();
        }
    }

    private void RestartGame()
    {
        Debug.Log("Reiniciando el juego...");
        uiManager?.HideGameOverPanel();
        uiManager?.ResumeGame();
        scoreManager?.ResetScore();
        lifeManager?.ResetLives();
        LoadScene("Scene1");
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
            Debug.Log("jaso");
            int finalScore = scoreManager.CurrentScore;
            uiManager.ShowGameOverPanel(finalScore);
        }
    }


    private void HandleLevelComplete()
    {
        Debug.Log("Level finished.");
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            string levelName = SceneManager.GetActiveScene().name;
            uiManager?.ShowLevelCompletePanel(levelName);


        }
    }
}