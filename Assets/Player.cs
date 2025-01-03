using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hat"))
        {
            Debug.Log("¡El jugador ha colisionado con un obstáculo!");
            EventManager.OnPlayerHitHat();
        }
        if (other.CompareTag("Teapot"))
        {
            Debug.Log("¡El jugador ha colisionado con una tetera!");
            EventManager.OnPlayerHitTeapot();
        }

    } 
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hat"))
        {
            EventManager.OnPlayerSurvivedObstacle();
        }
        if (other.CompareTag("Teapot"))
        {
            Debug.Log("¡El jugador no ha colisionado con una tetera!");
        }
    }
}