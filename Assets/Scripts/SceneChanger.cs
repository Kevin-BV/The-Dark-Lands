using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName = "NombreDeTuEscena";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener el componente PlayerController del jugador
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                // Llamar al método ChangeScene para cambiar a la escena deseada
                player.ChangeScene(sceneName);
            }
        }
    }
}
