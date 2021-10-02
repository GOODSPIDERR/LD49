using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetMoment : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    Rigidbody hatMagnet, rb;
    public CharacterMovement characterMovement;
    public Transform pole;
    public GameObject character;
    float turnSmoothVelocity;
    bool magnetised, attached;
    Vector3 initialPosition;
    Quaternion initialRotation;
    public GameObject ballOfMagnet;
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
                ball.transform.SetParent(null);
                ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            magnetised = false;
        }

        if (magnetised)
        {
            if (!attached)
            {
                Vector3 positionDifference = pole.position - hatMagnet.position;
                hatMagnet.transform.SetParent(null);
                hatMagnet.isKinematic = false;

                hatMagnet.AddForce(positionDifference * 200f * Time.deltaTime);
                characterMovement.canMove = false;
                character.transform.SetParent(hatMagnet.transform);
                character.GetComponent<Rigidbody>().isKinematic = true;
                hatMagnet.gameObject.GetComponent<BoxCollider>().enabled = true;

                //float targetAngle = Mathf.Atan2(positionDifference.x, positionDifference.y) * Mathf.Rad2Deg;
                //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 1f);
                //hatMagnet.transform.rotation = Quaternion.Euler(0, 0, angle);

                Debug.Log(positionDifference.magnitude);
            }

            else
            {
                Vector3 positionDifference = pole.position - hatMagnet.position;
                hatMagnet.isKinematic = true;

                characterMovement.canMove = false;
                character.transform.SetParent(hatMagnet.transform);
                character.GetComponent<Rigidbody>().isKinematic = true;
                hatMagnet.gameObject.GetComponent<BoxCollider>().enabled = false;
            }

        }

        else
        {
            character.GetComponent<Rigidbody>().isKinematic = false;
            characterMovement.canMove = true;
            hatMagnet.isKinematic = true;

            character.transform.SetParent(null);
            hatMagnet.transform.SetParent(character.transform);
            hatMagnet.transform.localPosition = initialPosition;
            hatMagnet.transform.localRotation = initialRotation;
            characterMovement.BackToNormal();
            hatMagnet.gameObject.GetComponent<BoxCollider>().enabled = false;
            attached = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hat")
        {
            attached = true;
        }
    }


}
