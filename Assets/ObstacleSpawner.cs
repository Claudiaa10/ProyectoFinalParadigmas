using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Parameters")]
    public GameObject obstaclePrefab; // Prefab del obstáculo
    public float spawnRate = 2f; // Frecuencia con la que aparecen los obstáculos
    public float minHeight = 1f; // Altura mínima del obstáculo
    public float maxHeight = 3f; // Altura máxima del obstáculo

    private List<GameObject> obstacles = new List<GameObject>(); // Lista para rastrear los obstáculos creados

    private void Start()
    {
        // Comienza a generar obstáculos a intervalos regulares
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    public void DestroyAllObstacles()
    {
        // Destruye todos los obstáculos creados
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }

        obstacles.Clear(); // Limpia la lista de obstáculos
    }

    public void Spawn()
    {
        // Crea un nuevo obstáculo a partir del Prefab
        GameObject newObstacle = Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity);

        // Ajusta la posición del obstáculo
        float randomHeight = Random.Range(minHeight, maxHeight); // Altura aleatoria
        Debug.Log("Generated Height: " + randomHeight); // Verifica la altura generada
        newObstacle.transform.position = new Vector3(5f, randomHeight, 0f); // Genera el obstáculo fuera del borde derecho

        // Agrega el obstáculo a la lista para rastrear su existencia
        obstacles.Add(newObstacle);

        // Configura el obstáculo para que se destruya después de 10 segundos
        Destroy(newObstacle, 10f);
    }
}

