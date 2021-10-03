using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMagnet : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public Transform targetMagnet;
    Rigidbody rb;
    bool magnetised;
    Vector3 initialPosition;
    Quaternion initialRotation;
    BoxCollider boxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
        boxCollider = GetComponent<BoxCollider>();
    }
    void Update()
    {
        if (magnetised)
        {
            Vector3 magnetDifference = targetMagnet.position - transform.position;
            float magnetDistance = Vector3.Distance(targetMagnet.position, transform.position);
            //rb.AddForce(magnetDifference * 10000 / magnetDistance * Time.deltaTime);

            //rb.AddForce(Input.GetAxis("Horizontal") * 100 * Time.deltaTime, 0f, 0f);

            //Debug.Log(magnetDistance);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            characterMovement.magnetised = true;
            magnetised = true;
            targetMagnet = other.transform;
            characterMovement.otherMagnet = other.transform;
            //rb.isKinematic = false;
            //rb.useGravity = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            characterMovement.magnetised = false;
            magnetised = false;
            //rb.isKinematic = true;
            //rb.useGravity = false;
            //Recovery();
        }
    }

    IEnumerator Recovery()
    {
        boxCollider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        boxCollider.enabled = true;
    }
}
