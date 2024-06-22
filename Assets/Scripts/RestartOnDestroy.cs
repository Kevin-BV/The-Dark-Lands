using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnDestroy : MonoBehaviour
{
    // Este m�todo se llama cuando el GameObject al que este script est� adjunto es destruido
    private void OnDestroy()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
