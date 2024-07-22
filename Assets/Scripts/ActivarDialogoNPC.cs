using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDialogoNPC : MonoBehaviour
{
    public GameObject dialogoNPC; // Referencia al objeto DialogoNPC

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador ha entrado en el trigger de SabioErrante."); // Mensaje de depuración
            dialogoNPC.SetActive(true); // Activa el objeto DialogoNPC cuando el jugador entra en el trigger
        }
    }
}