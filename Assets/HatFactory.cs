using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HatFactory : ObstacleFactory 
{
    [SerializeField] private Obstacle hatPrefab;
    public override Obstacle CreateObstacle(Vector3 spawnPosition)
{
    // Carga el prefab din�micamente si no est� asignado
    if (hatPrefab == null)
    {
        hatPrefab = Resources.Load<Obstacle>("Hat"); // Aseg�rate de que el prefab se llama "Teapot" en la carpeta Resources
        if (hatPrefab == null)
        {
            Debug.LogError("No se encontr� el prefab 'Teapot' en la carpeta Resources.");
            return null;
        }
    }

    // Instancia el prefab en la posici�n especificada
    Obstacle teapot = Instantiate(hatPrefab, spawnPosition, Quaternion.identity);
    return teapot;
}
}
 