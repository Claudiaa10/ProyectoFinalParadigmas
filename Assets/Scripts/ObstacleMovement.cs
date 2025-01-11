using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del obst�culo

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // Mueve el obst�culo hacia la izquierda

        if (transform.position.x < -10f) // Destruye el obst�culo fuera de la pantalla
        {
            Destroy(gameObject);
        }
    }
}
