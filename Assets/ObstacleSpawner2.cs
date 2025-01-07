using UnityEngine;

public class ObstacleSpawner2 : MonoBehaviour
{
    [Header("Fabricas")]
    public TeapotFactory teapotFactory;      
    public HatFactory hatFactory;   

    [Header("Parámetros de generación")]
    public float spawnRate = 2f;
    public float spawnX = 5f;
    public float startDelay = 3f;
    public float height = 1f;
    public float durationTime = 10f;

    private void Start()
    {
        InvokeRepeating("Spawn", startDelay, spawnRate);
    }

    private void Spawn()
    {
        Vector3 spawnVector = new Vector3(spawnX,height,0f);
        Obstacle newObstacle;

        if (Random.Range(0f, 1f) > 0.4f)
        {

            newObstacle = teapotFactory.CreateObstacle(spawnVector);
        }
        else
        {

            newObstacle = hatFactory.CreateObstacle(spawnVector);
        }
        Destroy(newObstacle,10f);

        Debug.Log($"Se generó un obstáculo: {newObstacle.name}");
    }
}
