using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnDestroy : MonoBehaviour
{
    // Este método se llama cuando el GameObject al que este script está adjunto es destruido
    private void OnDestroy()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
