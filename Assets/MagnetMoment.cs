using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetMoment : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    Rigidbody hatMagnet;
    public CharacterMovement characterMovement;
    void Start()
    {
        hatMagnet = GameObject.FindGameObjectWithTag("Hat").GetComponent<Rigidbody>();
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButton(1) && hit.collider.tag == "Magnet")
            {
                Vector3 positionDifference = transform.position - hatMagnet.position;
                hatMagnet.AddForce(positionDifference * 10f * Time.deltaTime);
                characterMovement.canMove = false;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            characterMovement.canMove = true;
        }
    }

}
