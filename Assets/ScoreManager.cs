using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int currentScore;
    private int highScore;
    public int CurrentScore => currentScore;
    public int HighScore => highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

  
    public void AddPoints(int points)
    {
        currentScore += points;
        Debug.Log($"Puntos añadidos: {points}. Puntuación actual: {currentScore}");

        if (currentScore > highScore)
        {
            highScore = currentScore;
            Debug.Log($"Nuevo récord: {highScore}");
        }

    
        EventManager.OnScoreChanged(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        Debug.Log("Puntuación reiniciada.");
        EventManager.OnScoreChanged(currentScore);
    }
}


