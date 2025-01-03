using UnityEngine;

public class InfiniteBackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f; // Velocidad del desplazamiento
    public float backgroundWidth = 20f; // Ancho total del fondo

    void Update()
    {
        // Desplazar el fondo hacia la izquierda
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Reiniciar la posición cuando el fondo salga completamente de la pantalla
        if (transform.position.x <= -backgroundWidth)
        {
            transform.position = new Vector3(backgroundWidth, transform.position.y, transform.position.z);
        }
    }
}
