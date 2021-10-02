using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalProp : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Transform hatMagnet;
    Rigidbody rb;
    bool magnetised;

    void Start()
    {
        hatMagnet = GameObject.FindGameObjectWithTag("Hat").transform;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Prop")
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
            Vector3 distance = hatMagnet.position - transform.position;
            rb.AddForce(distance * 1000f * Time.deltaTime);
        }
    }
}
