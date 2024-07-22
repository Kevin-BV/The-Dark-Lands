using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float followDistance = 5f; // Distancia a la que el enemigo empieza a seguir al jugador
    public float flyUpForce = 5f; // Fuerza para volar hacia arriba
    public float flyDuration = 3f; // Duración del vuelo

    private Animator animator; // Referencia al componente Animator
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D

    private bool isFlying = false;

    private void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator del enemigo
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D del enemigo
    }

    private void Update()
    {
        if (!isFlying)
        {
            // Verifica si el jugador está dentro de la distancia de seguimiento
            if (Vector2.Distance(transform.position, player.position) <= followDistance)
            {
                // Calcular la dirección hacia la que debe moverse el enemigo
                Vector2 direction = (player.position - transform.position).normalized;

                // Mueve al enemigo hacia la posición del jugador
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // Activar la animación de correr si la velocidad no es cero
                animator.SetFloat("Speed", speed);
            }
            else
            {
                // Si el jugador está fuera de la distancia, detener la animación de correr
                animator.SetFloat("Speed", 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mushroom"))
        {
            Destroy(collision.gameObject); // Destruir el hongo
            StartCoroutine(FlyUpCoroutine()); // Iniciar la rutina para volar hacia arriba
        }
    }

    private IEnumerator FlyUpCoroutine()
    {
        isFlying = true;
        animator.SetFloat("Speed", 0f); // Detener la animación de correr
        rb.velocity = new Vector2(rb.velocity.x, flyUpForce); // Aplicar fuerza hacia arriba

        yield return new WaitForSeconds(flyDuration); // Esperar durante el tiempo de vuelo

        rb.velocity = new Vector2(rb.velocity.x, 0f); // Detener el movimiento vertical
        isFlying = false;
    }

    private void OnDrawGizmos()
    {
        // Dibuja un círculo rojo alrededor del enemigo con el radio de followDistance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followDistance);
    }
}
