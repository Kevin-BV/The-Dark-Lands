using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    // Este método será llamado cuando se presione el botón de pausa
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

    // Método para pausar el juego
    void PauseGame()
    {
        Time.timeScale = 0f;  // Detener el tiempo
        isPaused = true;
    }

    // Método para reanudar el juego
    void ResumeGame()
    {
        Time.timeScale = 1f;  // Reiniciar el tiempo
        isPaused = false;
    }
}
