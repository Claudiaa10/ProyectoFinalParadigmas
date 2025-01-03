using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HatFactory : ObstacleFactory
{
    public GameObject hatPrefab;

    public override Obstacle CreateObstacle()
    {
        if (hatPrefab == null)
        {
            Debug.LogError("Hat prefab no asignado en HatFactory.");
            return null;
        }

        // Instanciar el prefab
        GameObject obstacleInstance = Instantiate(hatPrefab);

        // Retornar el componente Obstacle
        return obstacleInstance.GetComponent<Obstacle>();
    }
}
