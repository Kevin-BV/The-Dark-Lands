using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; // Nombre de la escena del men� principal

    public void OnReturnToMainMenuButtonClicked()
    {
        // Cargar la escena del men� principal
        SceneManager.LoadScene(mainMenuSceneName);
    }
}