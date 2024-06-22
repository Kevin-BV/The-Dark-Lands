using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // M�todo para cambiar a una escena espec�fica
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // M�todo para recargar la escena actual
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
