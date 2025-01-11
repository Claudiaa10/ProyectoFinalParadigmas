using UnityEngine;

public class TeapotFactory : ObstacleFactory
{
    [SerializeField] private Obstacle teapotPrefab; // Prefab que será asignado desde el Inspector o cargado a la fuerza

    public override Obstacle CreateObstacle(Vector3 spawnPosition)
    {
        // Carga el prefab dinámicamente si no está asignado
        if (teapotPrefab == null)
        {
            teapotPrefab = Resources.Load<Obstacle>("Teapot"); // Asegúrate de que el prefab se llama "Teapot" en la carpeta Resources
            if (teapotPrefab == null)
            {
                Debug.LogError("No se encontró el prefab 'Teapot' en la carpeta Resources.");
                return null;
            }
        }

        // Instancia el prefab en la posición especificada
        Obstacle teapot = Instantiate(teapotPrefab, spawnPosition, Quaternion.identity);
        return teapot;
    }
}
 
