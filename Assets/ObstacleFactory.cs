using UnityEngine;

public abstract class ObstacleFactory : MonoBehaviour
{
    [SerializeField] private Obstacle obstaclePrefab;
    public abstract Obstacle CreateObstacle(Vector3 spawnPosition);
   
}