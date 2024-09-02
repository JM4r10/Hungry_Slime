using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    //Datos requeridos
    private Rigidbody playerRigidbody;
    private GameManager gameManager;
    float movX, movZ;
    [SerializeField] float degrees, speed, jumpForce;
    [SerializeField] bool isJumping;
    private Vector3 movement;

    void Start()
    {
        //Referencia Componente RigidBody
        playerRigidbody = GetComponent<Rigidbody>();
        gameManager = GameManager.Instance;
     }

    // Update is called once per frame
    void Update()
    {
        //Guardamos los inputs en MovX y movZ
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        //En este Vector3 Decimos que almacene el valor y lo asigne al eje Z
        movement = transform.forward * movZ;

        //Si Oprimo Barra espaciadora y NO estoy saltando
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // Añado fuerza ascendente con una fuerza en modo de impulso
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {

        //Si estoy presionando los botones de movimiento
        if (movX != 0 || movZ != 0)
        {
            //Muevo a mi personaje de manera frontal
            playerRigidbody.MovePosition(transform.position + speed * Time.deltaTime * movement);
            //Roto para poder dirigirlo
            transform.Rotate(0, movX * degrees, 0);
        }
    }

    //Si entro en colisión con algún collider
    private void OnCollisionStay(Collision other)
    {

        //Verifico si el collider tiene tag de SolidGround
        if (other.gameObject.CompareTag("SolidGround"))
        {
            //Significa que NO estoy saltando
            isJumping = false;
        }

    }
    //Si dejo de colisionar con algún collider
    private void OnCollisionExit(Collision other)
    {

        //Si ese collider tiene tag SolidGround
        if (other.gameObject.CompareTag("SolidGround"))
        {
            //Estoy saltando
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        //Si ese collider tiene tag Food
        if (other.gameObject.CompareTag("Food"))
        {
            //Player come Food
            gameManager.ReduceFood();
            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("LimitLose"))
        {
            //Player come Food
            gameManager.GameOver();
        }
    }

}
