using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f; // Velocidad de movimiento del personaje
    private Animator animator; // Referencia al componente Animator


    void Start ()
    {
        // Obtener la referencia al componente Animator
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
        // Obtener la entrada del teclado para las teclas de flecha
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Definir la dirección de movimiento basada en las teclas presionadas
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (movementDirection != Vector3.zero)
        {
            // Rotar el personaje cuando se presiona "A" o la flecha izquierda
            if (Input.GetKeyDown(KeyCode.A) || horizontalInput < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180, 0f);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            // Rotar el personaje cuando se presiona la flecha derecha
            else if (horizontalInput > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0, 0f);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            // Mover el personaje hacia adelante cuando se presiona "W" o la flecha arriba
            if (Input.GetKey(KeyCode.W) || verticalInput > 0)
            {
                transform.rotation = Quaternion.Euler(0f, -90, 0f);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            // Mover el personaje hacia atrás cuando se presiona la flecha abajo
            else if (Input.GetKey(KeyCode.S) || verticalInput < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 90, 0f);

                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            animator.SetBool("RunForward", true);
            
        }
        else
        {
            animator.SetBool("RunForward", false);
        }

        if (Input.GetMouseButtonDown(0)) // 0 corresponde al clic izquierdo del mouse
        {
            
            animator.SetTrigger("Attack01"); // Activa la animación de ataque
        }

        if (Input.GetMouseButtonDown(1)) // 0 corresponde al clic derecho del mouse
        {
            animator.SetTrigger("Defend01"); // Activa la animación de ataque
        }
        


        
    }
}
