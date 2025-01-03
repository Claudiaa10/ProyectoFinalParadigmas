using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TeapotFactory : ObstacleFactory
{
    public GameObject teapotPrefab;

    public override Obstacle CreateObstacle()
    {
        if (teapotPrefab == null)
        {
            Debug.LogError("Teapot prefab no asignado en TeapotFactory.");
            return null;
        }

        // Instanciar el prefab
        GameObject obstacleInstance = Instantiate(teapotPrefab);

        // Retornar el componente Obstacle
        return obstacleInstance.GetComponent<Obstacle>();
    }
}

