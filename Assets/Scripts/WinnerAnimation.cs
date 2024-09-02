using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerAnimation : MonoBehaviour
{
    //Datos requeridos
    private Rigidbody playerRigidbody;
    [SerializeField] float jumpForce;
    [SerializeField] bool isJumping;
    
    void Start()
    {
        //Referencia Componente RigidBody
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if (!isJumping)
        {
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
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
}
