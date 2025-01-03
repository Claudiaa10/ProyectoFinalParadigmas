using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Parameters")]
    public GameObject obstaclePrefab; // Prefab del obst�culo
    public float spawnRate = 2f; // Frecuencia con la que aparecen los obst�culos
    public float minHeight = 1f; // Altura m�nima del obst�culo
    public float maxHeight = 3f; // Altura m�xima del obst�culo

    private List<GameObject> obstacles = new List<GameObject>(); // Lista para rastrear los obst�culos creados

    private void Start()
    {
        // Comienza a generar obst�culos a intervalos regulares
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    public void DestroyAllObstacles()
    {
        // Destruye todos los obst�culos creados
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }

        obstacles.Clear(); // Limpia la lista de obst�culos
    }

    public void Spawn()
    {
        // Crea un nuevo obst�culo a partir del Prefab
        GameObject newObstacle = Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity);

        // Ajusta la posici�n del obst�culo
        float randomHeight = Random.Range(minHeight, maxHeight); // Altura aleatoria
        Debug.Log("Generated Height: " + randomHeight); // Verifica la altura generada
        newObstacle.transform.position = new Vector3(5f, randomHeight, 0f); // Genera el obst�culo fuera del borde derecho

        // Agrega el obst�culo a la lista para rastrear su existencia
        obstacles.Add(newObstacle);

        // Configura el obst�culo para que se destruya despu�s de 10 segundos
        Destroy(newObstacle, 10f);
    }
}

