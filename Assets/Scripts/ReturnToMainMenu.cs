using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; // Nombre de la escena del menú principal

    public void OnReturnToMainMenuButtonClicked()
    {
        // Cargar la escena del menú principal
        SceneManager.LoadScene(mainMenuSceneName);
    }
}