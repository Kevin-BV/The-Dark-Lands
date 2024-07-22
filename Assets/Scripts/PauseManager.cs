using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    // Este m�todo ser� llamado cuando se presione el bot�n de pausa
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    // M�todo para pausar el juego
    void PauseGame()
    {
        Time.timeScale = 0f;  // Detener el tiempo
        isPaused = true;
    }

    // M�todo para reanudar el juego
    void ResumeGame()
    {
        Time.timeScale = 1f;  // Reiniciar el tiempo
        isPaused = false;
    }
}
