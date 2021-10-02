using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetMoment : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    Rigidbody hatMagnet, rb;
    public CharacterMovement characterMovement;
    public GameObject character;
    Vector3 initialPosition;
    Quaternion initialRotation;
    public GameObject ballOfMagnet;
    public bool magnetised;
    void Start()
    {
        hatMagnet = GameObject.FindGameObjectWithTag("Hat").GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        initialPosition = hatMagnet.transform.localPosition;
        initialRotation = hatMagnet.transform.localRotation;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(1) && hit.collider.tag == "Magnet")
            {
                var ball = Instantiate(ballOfMagnet, hit.transform);
                ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }

            if (Input.GetMouseButtonDown(0) && hit.transform == transform)
            {
                magnetised = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            magnetised = false;
        }

        if (magnetised)
        {
            Vector3 distance = hatMagnet.transform.position - transform.position;
            rb.AddForce(distance * 100f * Time.deltaTime);
        }
    }
}