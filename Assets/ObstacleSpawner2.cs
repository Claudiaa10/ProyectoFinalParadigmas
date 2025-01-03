using UnityEngine;

public class ObstacleSpawner2 : MonoBehaviour
{
    [Header("Prefabs de obstáculos")]
    public GameObject hatPrefab;       // Prefab del sombrero
    public GameObject teapotPrefab;    // Prefab de la tetera

    [Header("Parámetros de generación")]
    public float spawnRate = 2f;
    public float startDelay = 3f;// Frecuencia de aparición
    public float minHeight = 1f;       // Altura mínima del obstáculo
    public float maxHeight = 3f;       // Altura máxima del obstáculo

    [Header("Límite de Teapots")]
    public int maxTeapots = 3;         // Máximo número de teteras
    private int teapotCount = 0;       // Contador de teteras generadas

    private void Start()
    {
        // Generar obstáculos a intervalos regulares
        InvokeRepeating("Spawn", startDelay, spawnRate);
    }

    private void Spawn()
    {
        GameObject selectedPrefab;

        // Decidir qué obstáculo generar
        if (teapotCount < maxTeapots && Random.Range(0f, 1f) > 0.5f)
        {
            // Generar una tetera
            selectedPrefab = teapotPrefab;
            teapotCount++;
        }
        else
        {
            // Generar un sombrero
            selectedPrefab = hatPrefab;
        }

        // Instanciar el prefab seleccionado
        GameObject newObstacle = Instantiate(selectedPrefab);

        // Configurar la posición del obstáculo
        float randomHeight = Random.Range(minHeight, maxHeight);
        newObstacle.transform.position = new Vector3(5f, randomHeight, 0f);

        // Destruir el obstáculo después de 10 segundos para evitar saturar la escena
        Destroy(newObstacle, 10f);

        Debug.Log($"Se generó un obstáculo: {newObstacle.name}");
    }
}
