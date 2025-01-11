using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HatFactory : ObstacleFactory 
{
    [SerializeField] private Obstacle hatPrefab;
    public override Obstacle CreateObstacle(Vector3 spawnPosition)
{
 
    if (hatPrefab == null)
    {
        hatPrefab = Resources.Load<Obstacle>("Hat"); 
        if (hatPrefab == null)
        {
            Debug.LogError("No se encontró el prefab 'Teapot' en la carpeta Resources.");
            return null;
        }
    }

    Obstacle teapot = Instantiate(hatPrefab, spawnPosition, Quaternion.identity);
    return teapot;
}
}
 