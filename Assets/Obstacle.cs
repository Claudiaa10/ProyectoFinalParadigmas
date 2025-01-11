using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 3f;
    public float maxDist = 10f;

    private void Update()
    {
        ObstacleMovement();
       
    }

    private void ObstacleMovement()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
  

}
 