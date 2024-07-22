using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Nombre de la escena que queremos cargar al presionar el bot�n "Jugar"
    public string sceneToLoad = "NombreDeTuEscena";

    // M�todo p�blico llamado por el bot�n "Jugar" en el men� principal
    public void OnPlayButtonClicked()
    {
        // Cargar la escena especificada
        SceneManager.LoadScene(sceneToLoad);
    }

    // M�todo p�blico para salir del juego (opcional)
    public void OnQuitButtonClicked()
    {
        // Salir de la aplicaci�n (solo funciona en build)
        Application.Quit();
    }
}