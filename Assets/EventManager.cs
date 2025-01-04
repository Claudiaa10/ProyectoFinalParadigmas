using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditorInternal;
using UnityEngine.Events;

public static class EventManager
{
    // Eventos est�ticos que otros scripts pueden suscribirse
    public static event UnityAction PlayerHitHat;
    public static event UnityAction PlayerHitTeapot;
    public static event UnityAction PlayerSurvivedObstacle;
    public static event UnityAction LevelComplete;
    public static event UnityAction RestartGame;

    // M�todo para invocar el evento cuando el jugador colisiona con un Hat
    public static void OnPlayerHitHat()
    {
        PlayerHitHat?.Invoke();
    }

    public static void OnRestartGame() 
    { 
        RestartGame?.Invoke();
    }

    // M�todo para invocar el evento cuando el jugador colisiona con un Teapot
    public static void OnPlayerHitTeapot()
    {
        PlayerHitTeapot?.Invoke();
    }

    // M�todo para invocar el evento cuando el jugador sobrevive a un obst�culo
    public static void OnPlayerSurvivedObstacle()
    {
        PlayerSurvivedObstacle?.Invoke();
    }

    // M�todo para invocar el evento cuando el nivel se completa
    public static void OnLevelComplete()
    {
        LevelComplete?.Invoke();
    }
}

