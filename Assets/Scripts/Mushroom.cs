using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si ha colisionado con el jugador, el enemigo o cualquier objeto con el tag "Ground"
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy") || collision.CompareTag("Ground"))
        {
            // Destruir el hongo cuando colisione con el jugador, el enemigo o el suelo
            Destroy(gameObject);
        }
    }
}

