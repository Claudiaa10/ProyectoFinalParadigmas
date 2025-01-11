using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hat"))
        {
            Debug.Log("¡El jugador ha colisionado con un obstáculo!");
            Destroy(other.gameObject);
            EventManager.OnPlayerHitHat();
        }
        if (other.CompareTag("Teapot"))
        {
            Debug.Log("¡El jugador ha colisionado con una tetera!");
            Destroy(other.gameObject);
            Debug.Log("tetera destruida");
            EventManager.OnPlayerHitTeapot();
        }

        if (other.CompareTag("Key"))
        {
            Debug.Log("¡El jugador ha colisionado con una tetera!");
            Destroy(other.gameObject);
            EventManager.OnPlayerHitKey();
        }


    } 
}