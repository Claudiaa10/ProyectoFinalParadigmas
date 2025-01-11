using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del obstáculo

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // Mueve el obstáculo hacia la izquierda

        if (transform.position.x < -10f) // Destruye el obstáculo fuera de la pantalla
        {
            Destroy(gameObject);
        }
    }
}
