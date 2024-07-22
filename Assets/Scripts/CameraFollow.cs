using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objetivo que la c�mara seguir� (en este caso, el jugador)
    public Vector3 offset; // La distancia entre la c�mara y el objetivo
    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el seguimiento de la c�mara

    void LateUpdate()
    {
        // Posici�n deseada de la c�mara
        Vector3 desiredPosition = target.position + offset;

        // Interpolar entre la posici�n actual de la c�mara y la posici�n deseada para un movimiento suave
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Establecer la posici�n de la c�mara
        transform.position = smoothedPosition;
    }
}