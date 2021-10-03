using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public bool lever;
    void Start()
    {
        hatMagnet = GameObject.FindGameObjectWithTag("Hat").GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
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

        if (magnetised && !lever)
        {
            if (rb.isKinematic)
            {
                magnetised = false;
                transform.position = initialPosition;
                transform.DOShakePosition(1f, 0.1f, 10, 90f, false, true).OnComplete(() => transform.DOMove(initialPosition, 0.5f, false));
            }
            else
            {
                Vector3 distance = hatMagnet.transform.position - transform.position;
                rb.AddForce(distance * 100f * Time.deltaTime);
            }

        }
    }
}