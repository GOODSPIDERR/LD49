using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBall : MonoBehaviour
{
    Transform invisibleCursor;
    public Rigidbody hatMagnet;
    public CharacterMovement characterMovement;
    public GameObject character;
    bool attached;
    private void Start()
    {
        invisibleCursor = GameObject.FindGameObjectWithTag("Cursor").transform;
    }
    void Update()
    {
        Vector3 distance = transform.position - invisibleCursor.position;
        float newScale = Mathf.Clamp(distance.magnitude, 0.01f, 10f);
        transform.localScale = new Vector3(newScale, newScale, newScale);

        if (Input.GetMouseButtonUp(1))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!attached)
        {
            Vector3 positionDifference = transform.position - hatMagnet.position;
            hatMagnet.transform.SetParent(null);
            hatMagnet.isKinematic = false;

            hatMagnet.AddForce(positionDifference * 200f * Time.deltaTime);
            characterMovement.canMove = false;
            character.transform.SetParent(hatMagnet.transform);
            character.GetComponent<Rigidbody>().isKinematic = true;
            hatMagnet.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
