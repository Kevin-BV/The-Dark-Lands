using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float followDistance = 5f; // Distancia a la que el enemigo empieza a seguir al jugador

    private Animator animator; // Referencia al componente Animator

    private void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator del enemigo
    }

    private void Update()
    {
        // Verifica si el jugador est� dentro de la distancia de seguimiento
        if (Vector2.Distance(transform.position, player.position) <= followDistance)
        {
            // Calcular la direcci�n hacia la que debe moverse el enemigo
            Vector2 direction = (player.position - transform.position).normalized;

            // Limitar la rotaci�n a dos direcciones (izquierda y derecha)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Si la direcci�n X del jugador es mayor que la del enemigo, mira a la derecha; de lo contrario, mira a la izquierda
            if (direction.x >= 0)
                transform.rotation = Quaternion.Euler(0, 0, 0); // Mirar hacia la derecha
            else
                transform.rotation = Quaternion.Euler(0, 180, 0); // Mirar hacia la izquierda

            // Mueve al enemigo hacia la posici�n del jugador
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Activar la animaci�n de correr si la velocidad no es cero
            animator.SetFloat("Speed", speed);
        }
        else
        {
            // Si el jugador est� fuera de la distancia, detener la animaci�n de correr
            animator.SetFloat("Speed", 0f);
        }
    }

    private void OnDrawGizmos()
    {
        // Dibuja un c�rculo rojo alrededor del enemigo con el radio de followDistance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followDistance);
    }
}