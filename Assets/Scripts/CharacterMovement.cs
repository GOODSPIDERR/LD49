using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public bool canMove = true;
    Rigidbody rb;
    public float movementSpeed = 1f;
    float velocity;
    public Transform groundCheck;
    public bool isGrounded;
    public LayerMask groundLayer;
    public float jumpForce = 5f;
    public Transform graphics;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (canMove) Move(movementVector);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canMove) Jump();

    }

    void Move(Vector2 movementVector)
    {
        rb.transform.Translate(movementVector.x * movementSpeed * Time.deltaTime, 0, 0);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
