using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objetivo que la cámara seguirá (en este caso, el jugador)
    public Vector3 offset; // La distancia entre la cámara y el objetivo
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el seguimiento de la cámara

    void LateUpdate()
    {
        // Posición deseada de la cámara
        Vector3 desiredPosition = target.position + offset;

        // Interpolar entre la posición actual de la cámara y la posición deseada para un movimiento suave
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Establecer la posición de la cámara
        transform.position = smoothedPosition;
    }
}