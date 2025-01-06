using UnityEngine;

public class ObstacleSpawner2 : MonoBehaviour
{
    [Header("Prefabs de obstáculos")]
    public GameObject hatPrefab;      
    public GameObject teapotPrefab;   

    [Header("Parámetros de generación")]
    public float spawnRate = 2f;
    public float spawnX = 5f;
    public float startDelay = 3f;
    public float Height = 1f;

    private void Start()
    {
        InvokeRepeating("Spawn", startDelay, spawnRate);
    }

    private void Spawn()
    {
        GameObject selectedPrefab;

        if (Random.Range(0f, 1f) > 0.4f)
        {
            
            selectedPrefab = teapotPrefab;
        }
        else
        {
            
            selectedPrefab = hatPrefab;
        }

        GameObject newObstacle = Instantiate(selectedPrefab);
        newObstacle.transform.position = new Vector3(spawnX, Height, 0f);

        Destroy(newObstacle, 10f);

        Debug.Log($"Se generó un obstáculo: {newObstacle.name}");
    }
}
