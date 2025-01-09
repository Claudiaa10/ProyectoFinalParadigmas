using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    public void Setup(string levelName)
    {
        Debug.Log($"LevelCompleteScreen: Mostrando nivel completado: {levelName}");

        // Activa el panel
        gameObject.SetActive(true);

        // Configura el texto con el nombre del nivel
        if (levelText != null)
        {
            levelText.text = $"Level {levelName}";
        }
        else
        {
            Debug.LogError("LevelCompleteScreen: El texto del nivel no está asignado.");
        }
    }

    public void ContinueButton()
    {
        Debug.Log("Continuando al siguiente nivel...");
        EventManager.OnNextLevel(); // Llama al evento para avanzar al siguiente nivel
    }

    public void ExitButton()
    {
        Debug.Log("Volviendo al menú principal...");
        SceneManager.LoadScene("MainMenu");
    }
}
