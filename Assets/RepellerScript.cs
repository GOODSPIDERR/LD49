using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RepellerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 mousePosition;
    private Rigidbody2D button;
    private Vector2 direction;
    private float moveSpeed = 200f;
    private bool mouse_over = false;
    private Vector3 buttonStartPos;

    void Start()
    {
        button = GetComponent<Rigidbody2D>();
        buttonStartPos = transform.position;

    }


    public void Repel()
    {

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (transform.position - mousePosition).normalized;
            Vector2 newPos = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
            button.velocity = newPos;
    }

    public void Comeback()
    {

        direction = (buttonStartPos - transform.position).normalized;
        Vector2 newPos = new Vector2(direction.x, direction.y);
        button.velocity = newPos;


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        Debug.Log("Mouse enter");
        Repel();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Debug.Log("Mouse exit");
        Comeback();
    }
}
