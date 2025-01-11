using UnityEngine;

public class TeapotFactory : ObstacleFactory
{
    [SerializeField] private Obstacle teapotPrefab; // Prefab que ser� asignado desde el Inspector o cargado a la fuerza

    public override Obstacle CreateObstacle(Vector3 spawnPosition)
    {
        // Carga el prefab din�micamente si no est� asignado
        if (teapotPrefab == null)
        {
            teapotPrefab = Resources.Load<Obstacle>("Teapot"); // Aseg�rate de que el prefab se llama "Teapot" en la carpeta Resources
            if (teapotPrefab == null)
            {
                Debug.LogError("No se encontr� el prefab 'Teapot' en la carpeta Resources.");
                return null;
            }
        }

        // Instancia el prefab en la posici�n especificada
        Obstacle teapot = Instantiate(teapotPrefab, spawnPosition, Quaternion.identity);
        return teapot;
    }
}
 
