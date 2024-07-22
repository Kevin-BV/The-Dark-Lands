using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlyingEnemyPatrol : MonoBehaviour
{
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    public float speed = 2f;

    private Vector3 targetPoint;
    private bool movingRight = true;

    private void Start()
    {
        // Inicia la patrulla hacia el primer punto
        targetPoint = patrolPoint1.position;
    }

    private void Update()
    {
        // Mueve al enemigo hacia el punto objetivo
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        // Verifica la dirección y rota el sprite si es necesario
        if (targetPoint.x > transform.position.x && !movingRight)
        {
            Flip();
        }
        else if (targetPoint.x < transform.position.x && movingRight)
        {
            Flip();
        }

        // Si el enemigo llega al punto objetivo, cambia al otro punto
        if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
        {
            targetPoint = targetPoint == patrolPoint1.position ? patrolPoint2.position : patrolPoint1.position;
        }
    }

    private void Flip()
    {
        // Cambia la dirección del sprite
        movingRight = !movingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        // Dibuja líneas entre los puntos de patrulla en la escena para visualizarlos
        if (patrolPoint1 != null && patrolPoint2 != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(patrolPoint1.position, patrolPoint2.position);
        }
    }
}