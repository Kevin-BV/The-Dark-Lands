using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject mushroomPrefab; // Prefab del hongo a lanzar
    public Transform launchPoint; // Punto de lanzamiento
    public float launchForce = 10f; // Fuerza de lanzamiento
    public int mushrooms = 0; // Cantidad de hongos recolectados

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mushrooms > 0)
        {
            LaunchMushroom();
        }
    }

    public void AddMushrooms(int amount)
    {
        mushrooms += amount;
    }

    void LaunchMushroom()
    {
        GameObject mushroom = Instantiate(mushroomPrefab, launchPoint.position, launchPoint.rotation);
        Rigidbody2D rb = mushroom.GetComponent<Rigidbody2D>();
        rb.velocity = launchPoint.right * launchForce;
        mushrooms--;
    }
}
