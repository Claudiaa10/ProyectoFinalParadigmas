using UnityEngine;

public class ObstacleSpawner2 : MonoBehaviour
{
    [Header("Prefabs de obst�culos")]
    public GameObject hatPrefab;       // Prefab del sombrero
    public GameObject teapotPrefab;    // Prefab de la tetera

    [Header("Par�metros de generaci�n")]
    public float spawnRate = 2f;
    public float startDelay = 3f;// Frecuencia de aparici�n
    public float minHeight = 1f;       // Altura m�nima del obst�culo
    public float maxHeight = 3f;       // Altura m�xima del obst�culo

    [Header("L�mite de Teapots")]
    public int maxTeapots = 3;         // M�ximo n�mero de teteras
    private int teapotCount = 0;       // Contador de teteras generadas

    private void Start()
    {
        // Generar obst�culos a intervalos regulares
        InvokeRepeating("Spawn", startDelay, spawnRate);
    }

    private void Spawn()
    {
        GameObject selectedPrefab;

        // Decidir qu� obst�culo generar
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

        // Configurar la posici�n del obst�culo
        float randomHeight = Random.Range(minHeight, maxHeight);
        newObstacle.transform.position = new Vector3(5f, randomHeight, 0f);

        // Destruir el obst�culo despu�s de 10 segundos para evitar saturar la escena
        Destroy(newObstacle, 10f);

        Debug.Log($"Se gener� un obst�culo: {newObstacle.name}");
    }
}
