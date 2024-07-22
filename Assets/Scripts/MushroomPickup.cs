using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPickup : MonoBehaviour
{
    public float speedBoost = 2f; // Aumento en la velocidad de movimiento
    public float jumpBoost = 5f; // Aumento en la fuerza de salto
    public float boostDuration = 10f; // Duración del aumento en segundos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Llamar al método en el PlayerController para aumentar los stats
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.BoostStats(speedBoost, jumpBoost, boostDuration);
            }
            // Destruir el hongo cuando el jugador lo recoge
            Destroy(gameObject);
        }
    }
}