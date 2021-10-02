using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingMagnet : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    private GameObject platform;
    private float startPositionX = -0.25f;
    private float endPositionX = 0.25f;
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
        platform.transform.DOLocalMoveX(endPositionX, duration, false);
    }
    public void GoBack()
    {
        platform.transform.DOLocalMoveX(startPositionX, duration, false);
    }

}
