using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController playerControl;
    GameManager gameManager;

    private float hInput, vInput;
    private readonly float gravity = -20f;
    [SerializeField] float speed;
    [SerializeField] float degreeMultiplier;
    [SerializeField] float jumpForce;

    Vector3 moveVelocity;
    Vector3 turnVelocity;
    void Start()
    {
        playerControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (playerControl.isGrounded)
        {
            moveVelocity = speed * vInput * transform.forward;
            turnVelocity = degreeMultiplier * hInput * transform.up;
            //DUDA: SALTO NO RESPONDE CUANDO ESTA GIRANDO movX + movZ;
            if (Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = jumpForce;
                moveVelocity.z += jumpForce * 0.1f;
            }

        }

        //adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        playerControl.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }

}



