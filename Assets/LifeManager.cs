using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance { get; private set; }
    private int currentLives;
    public int CurrentLives => currentLives;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RemoveLife()
    {
        currentLives--;
        EventManager.OnNumberLivesChanged(currentLives);
    }

    public void ResetLives()
    {
        currentLives = 2;
        Debug.Log("Vidas reiniciadas.");
        EventManager.OnNumberLivesChanged(currentLives);
    }
}
