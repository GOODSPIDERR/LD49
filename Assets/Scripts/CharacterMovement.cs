using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterMovement : MonoBehaviour
{
    public bool canMove = true;
    public bool doubleJumped;
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
    Animator animator;
    Vector3 initialPosition, initialHatPosition;
    Quaternion initialRotation, initialHatRotation;
    public Transform head;
    public Transform otherMagnet;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();

        initialHatPosition = headMagnet.transform.localPosition;
        initialHatRotation = headMagnet.transform.localRotation;
    }

    void Update()
    {
        if (magnetised)
        {
            canMove = false;
            Vector3 distance = otherMagnet.position - transform.position;
            rb.AddForce(distance * 500f / distance.magnitude * Time.deltaTime);
            rb.AddForce(Input.GetAxisRaw("Horizontal") * 100 * Time.deltaTime, 0, 0);
            Debug.Log(distance);
            //transform.rotation = Quaternion.LookRotation(distance, Vector3.left);
            //headMagnet.transform.SetParent(null);
            //transform.SetParent(headMagnet.transform);
            //rb.isKinematic = true;
            //rb.useGravity = false;
            //capsuleCollider.enabled = false;
            //transform.localPosition = new Vector3(0, 0, 0);
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            canMove = true;
            //transform.SetParent(null);
            //headMagnet.transform.SetParent(head);
            //rb.isKinematic = false;
            //rb.useGravity = true;
            //capsuleCollider.enabled = true;
            //BackToNormal(); //If you comment this out, it breaks the right click, but the rotation works fine
            //headMagnet.transform.localPosition = initialHatPosition;
            //headMagnet.transform.localRotation = initialHatRotation;

        }

        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (canMove) Move(movementVector);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.25f, groundLayer);

        //Debug.Log(magnetised);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canMove) Jump();

        //DOUBLE JUMPING SECTION....IF WE NEED TO IMPLEMENT IT
        if (isGrounded) doubleJumped = false;
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && !doubleJumped)
        {
            Jump();
            doubleJumped = true;
        }

        animator.SetBool("Magnetised", magnetised);

        animator.SetBool("IsGrounded", isGrounded);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
    void Move(Vector2 movementVector)
    {
        //movementTranslation += movementVector.x * acceleration * Time.deltaTime;
        //movementTranslation = Mathf.Clamp(movementTranslation, -movementSpeed, movementSpeed);

        //if (movementVector.x == 0) DOTween.To(() => movementTranslation, x => movementTranslation = x, new Vector2(0, 0), 1);

        rb.velocity = new Vector3(movementVector.x * movementSpeed, rb.velocity.y, 0);
        animator.SetFloat("Speed", Mathf.Abs(movementVector.x));
        //transform.rotation = Quaternion.LookRotation(movementVector);

        if (movementVector.x > 0) transform.rotation = Quaternion.Euler(transform.rotation.x, 90f, transform.rotation.z);
        else if (movementVector.x < 0) transform.rotation = Quaternion.Euler(transform.rotation.x, -90f, transform.rotation.z);
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        animator.SetTrigger("Jump");
    }


    public void BackToNormal()
    {
        boxColliderOnMagnet.enabled = false;
        transform.DORotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() => boxColliderOnMagnet.enabled = true);
    }
}
