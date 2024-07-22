using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        UpdateAnimation();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Actualizar la dirección de la animación en función del movimiento
        if (move != 0)
        {
            animator.SetBool("isRunning", true);
            if (move < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Voltear hacia la izquierda
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1); // Voltear hacia la derecha
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetTrigger("takeOff"); // Activar la animación de salto
        }
    }

    void UpdateAnimation()
    {
        // Actualizar el parámetro "isGrounded" en el Animator
        animator.SetBool("isGrounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnDestroy()
    {
        // Reiniciar la escena actual cuando el jugador se destruya
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Método para cambiar de escena cuando se activa el collider
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void BoostStats(float speedIncrease, float jumpIncrease, float duration)
    {
        StartCoroutine(BoostCoroutine(speedIncrease, jumpIncrease, duration));
    }

    private IEnumerator BoostCoroutine(float speedIncrease, float jumpIncrease, float duration)
    {
        moveSpeed += speedIncrease;
        jumpForce += jumpIncrease;
        yield return new WaitForSeconds(duration);
        moveSpeed -= speedIncrease;
        jumpForce -= jumpIncrease;
    }
}