using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Alice") // Asegúrate de que el nombre del objeto del jugador es correcto
        {
            EventManager.OnPlayerHitKey();
        }
    }
}
