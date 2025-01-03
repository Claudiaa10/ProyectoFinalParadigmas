using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int obstaclesSurvived = 0;
    public int totalObstacles = 15;

    private void OnEnable()
    {
        EventManager.PlayerSurvivedObstacle += HandleObstacleSurvived;
    }

    private void OnDisable()
    {
        EventManager.PlayerSurvivedObstacle -= HandleObstacleSurvived;
    }

    private void HandleObstacleSurvived()
    {
        obstaclesSurvived++;

        if (obstaclesSurvived >= totalObstacles)
        {
            EventManager.OnLevelComplete();
        }
    }
}
