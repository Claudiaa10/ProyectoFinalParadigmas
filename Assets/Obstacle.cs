using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 3f; // Velocidad del movimiento del obstáculo

    private void Update()
    {
        // Movimiento hacia la izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destruir el obstáculo si sale de la pantalla
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
 