
using UnityEngine.Events;

public static class EventManager
{
    
    public static event UnityAction PlayerHitHat;
    public static event UnityAction PlayerHitTeapot;
    public static event UnityAction PlayerSurvivedObstacle;
    public static event UnityAction LevelComplete;
    public static event UnityAction RestartGame;
    public static event UnityAction<int> ScoreChanged;
    public static event UnityAction<string> SceneLoaded;
    public static event UnityAction<int> LifeChanged;
    public static event UnityAction GameOver;
    public static event UnityAction PlayerAttacked;
    public static event UnityAction NextLevel;
    public static event UnityAction PlayerHitKey;

    public static void OnPlayerHitKey()
    {
        PlayerHitKey?.Invoke();
    }
    public static void OnNextLevel()
    {
        NextLevel?.Invoke();
    }
    public static void OnPlayerAttacked()
    {
        PlayerAttacked?.Invoke();
    }
    public static void OnPlayerHitHat()
    {
        PlayerHitHat?.Invoke();
    }

    public static void OnSceneLoaded(string sceneName)
    {
        SceneLoaded?.Invoke(sceneName);
    }
    public static void OnRestartGame() 
    { 
        RestartGame?.Invoke();
    }

    public static void OnPlayerHitTeapot()
    {
        PlayerHitTeapot?.Invoke();
    }

    public static void OnGameOver()
    {
        GameOver?.Invoke();
    }

    public static void OnPlayerSurvivedObstacle()
    {
        PlayerSurvivedObstacle?.Invoke();
    }

    
    public static void OnLevelComplete()
    {
        LevelComplete?.Invoke();
    }


    public static void OnScoreChanged(int newScore)
    {
        ScoreChanged?.Invoke(newScore);
    }

    public static void OnNumberLivesChanged(int nLives)
    {
        LifeChanged?.Invoke(nLives);
    }
}