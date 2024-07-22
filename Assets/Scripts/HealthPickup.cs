using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 1; // Cantidad de vida que recupera el ítem

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.CompareTag("Player"))
        {
            // Intenta obtener el componente PlayerHealth del jugador
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Recupera la vida del jugador
                playerHealth.Heal(healthAmount);

                // Desactiva o destruye el ítem después de recogerlo
                Destroy(gameObject);
            }
        }
    }
}
