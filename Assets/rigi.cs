using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Asegúrate de que el objeto con el que colisiona es Alice
        if (collision.gameObject.name == "Alice") // Idealmente, deberías usar tags para identificar a Alice
        {
            SaveGame();
            gameObject.SetActive(false); // Opcionalmente desactivar la llave después de tocarla
        }
    }

    void SaveGame()
    {
        // Aquí añadirías el código para guardar el juego
        Debug.Log("Juego guardado!");

        // Ejemplo de cómo podrías guardar la posición de Alice, usando PlayerPrefs (método simple)
        PlayerPrefs.SetFloat("AlicePosX", transform.position.x);
        PlayerPrefs.SetFloat("AlicePosY", transform.position.y);
        PlayerPrefs.Save(); // No olvides llamar a Save() para escribir en el disco

        // Puedes expandir este método para guardar otros aspectos del juego como el puntaje, vidas, etc.
    }
}
