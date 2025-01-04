using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI  pointsText;

    public void Setup(int points)
    {
        Debug.Log("GameOverScreen: Activando el objeto y configurando puntos.");

        // Activa el objeto `Gameover`
        gameObject.SetActive(true);

        // Asegúrate de que el texto se está actualizando correctamente
        if (pointsText != null)
        {
            pointsText.text = points.ToString() + " POINTS";
            Debug.Log($"GameOverScreen: Texto de puntos actualizado a {points} POINTS.");
        }
        else
        {
            Debug.LogError("GameOverScreen: El texto de puntos no está asignado.");
        }
    }


    public void RestartButton()
    {
        Debug.Log("pressed");
        EventManager.OnRestartGame();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}