using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Nombre de la escena que queremos cargar al presionar el botón "Jugar"
    public string sceneToLoad = "NombreDeTuEscena";

    // Método público llamado por el botón "Jugar" en el menú principal
    public void OnPlayButtonClicked()
    {
        // Cargar la escena especificada
        SceneManager.LoadScene(sceneToLoad);
    }

    // Método público para salir del juego (opcional)
    public void OnQuitButtonClicked()
    {
        // Salir de la aplicación (solo funciona en build)
        Application.Quit();
    }
}