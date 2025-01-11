using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int points)
    {
        Debug.Log("GameOverScreen: Activando el objeto y configurando puntos.");

        // Activa el objeto `GameOver`
        gameObject.SetActive(true);

        // Verifica si el texto de los puntos está configurado
        if (pointsText != null)
        {
            // Actualiza el texto de los puntos
            pointsText.text = points.ToString() + " POINTS";
            Debug.Log($"GameOverScreen: Texto de puntos actualizado a {points} POINTS.");
        }
        else
        {
            Debug.LogWarning("GameOverScreen: `pointsText` no está asignado. Los puntos no se mostrarán.");
        }
    }

    public void RestartButton()
    {
        Debug.Log("RestartButton presionado.");
        EventManager.OnRestartGame();
    }

    public void ExitButton()
    {
        Debug.Log("ExitButton presionado. Cargando MainMenu.");
        SceneManager.LoadScene("MainMenu");
    }
}
