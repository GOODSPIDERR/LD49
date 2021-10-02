using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingMagnet : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    private GameObject platform;
    [SerializeField] float startPosition; //for horizontal movement this value is -0.25f, for vertical it is 0.5f
    [SerializeField] float endPosition;  //for horizontal movement this value is 0.25f, for vertical, it is -0.5f
    float duration = 4f;

    void Start()
    {
        platform = this.transform.parent.gameObject;
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Magnet")
            {
                Move();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            GoBack();
        }
    }

    public void Move()
    {
        platform.transform.DOLocalMoveX(endPosition, duration, false);
    }
    public void GoBack()
    {
        platform.transform.DOLocalMoveX(startPosition, duration, false);
    }

}
