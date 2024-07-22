using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretDoor : MonoBehaviour
{
    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider;

    private void Start()
    {
        // Obtiene los componentes TilemapRenderer y TilemapCollider2D
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Desactiva el TilemapRenderer y el TilemapCollider2D
            tilemapRenderer.enabled = false;
            tilemapCollider.enabled = false;
        }
    }
}