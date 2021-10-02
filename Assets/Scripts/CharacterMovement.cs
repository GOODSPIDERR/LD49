using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterMovement : MonoBehaviour
{
    public bool canMove = true;
    Rigidbody rb;
    public float movementSpeed = 1f, acceleration = 1f;
    float velocity;
    public Transform groundCheck;
    public bool isGrounded;
    public LayerMask groundLayer, magnetLayer;
    public float jumpForce = 5f;
    public Transform graphics;
    public bool magnetised;
    public GameObject headMagnet;
    float movementTranslation = 0f;
    public BoxCollider boxColliderOnMagnet;
    CapsuleCollider capsuleCollider;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (magnetised)
        {
            canMove = false;
            headMagnet.transform.SetParent(null);
            transform.SetParent(headMagnet.transform);
            rb.isKinematic = true;
            rb.useGravity = false;
            capsuleCollider.enabled = false;
        }
        else
        {
            canMove = true;
            transform.SetParent(null);
            headMagnet.transform.SetParent(transform);
            rb.isKinematic = false;
            rb.useGravity = true;
            capsuleCollider.enabled = true;
            BackToNormal();
        }

        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (canMove) Move(movementVector);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        Debug.Log(magnetised);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canMove) Jump();

    }
    void Move(Vector2 movementVector)
    {
        //movementTranslation += movementVector.x * acceleration * Time.deltaTime;
        //movementTranslation = Mathf.Clamp(movementTranslation, -movementSpeed, movementSpeed);

        //if (movementVector.x == 0) DOTween.To(() => movementTranslation, x => movementTranslation = x, new Vector2(0, 0), 1);

        rb.transform.Translate(movementVector.x * movementSpeed * Time.deltaTime, 0, 0);
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    public void BackToNormal()
    {
        boxColliderOnMagnet.enabled = false;
        transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() => boxColliderOnMagnet.enabled = true);
    }
}
