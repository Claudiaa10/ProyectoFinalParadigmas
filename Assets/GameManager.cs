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
        EventManager.NextLevel += HandleNextLevel;
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

        // Aseg�rate de que el UIManager est� inicializado
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }

        if (uiManager != null)
        {
            // Obt�n la puntuaci�n final (opcional)
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
        Time.timeScale = 1;
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
            else if (currentLevelManager is Level3Manager level3Manager)
            {
                level3Manager.InitializeScoreManager(scoreManager);
                level3Manager.InitializeLifeManager(lifeManager);
            }

            currentLevelManager.StartLevel();

        }
        else
        {
            Debug.LogError("No se encontr� un LevelManager con el tag 'LevelManager'.");
        }
    }



    public void HandleNextLevel()
    {
        Debug.Log("Continuando al siguiente nivel...");
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // �ndice actual de la escena
        int nextSceneIndex = currentSceneIndex + 1; // Calcula el �ndice de la pr�xima escena

        Debug.Log($"Current Scene Index: {currentSceneIndex}");
        Debug.Log($"Next Scene Index: {nextSceneIndex}");
        Debug.Log($"Total Scenes in Build Settings: {SceneManager.sceneCountInBuildSettings}");

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
         
        }
        else
        {
            Debug.Log("No hay m�s niveles. Reiniciando el juego...");
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