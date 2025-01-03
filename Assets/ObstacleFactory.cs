using UnityEngine;

public abstract class ObstacleFactory : MonoBehaviour
{
    public abstract Obstacle CreateObstacle();
}