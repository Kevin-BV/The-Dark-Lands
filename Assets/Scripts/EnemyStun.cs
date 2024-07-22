using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStun : MonoBehaviour
{
    private bool isFrozen = false;
    private Rigidbody2D rb; // Referencia al Rigidbody2D del enemigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el Rigidbody2D del enemigo
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mushroom"))
        {
            Debug.Log("Collision detected with Mushroom!");
            StartCoroutine(FreezeCoroutine(2f)); // Congelar por 2 segundos al detectar el hongo
        }
    }

    private IEnumerator FreezeCoroutine(float duration)
    {
        isFrozen = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll; // Congelar todas las posiciones y rotación

        yield return new WaitForSeconds(duration);

        isFrozen = false;
        rb.constraints = RigidbodyConstraints2D.None; // Permitir movimiento nuevamente
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Congelar solo la rotación
    }

    void Update()
    {
        // Aquí puedes agregar comportamientos adicionales mientras no esté congelado
        if (!isFrozen)
        {
            // Comportamiento normal del enemigo
        }
    }
}