using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RepellerScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] Vector2 startPosition; 
    [SerializeField] Vector2 endPosition; 
    float duration = 2f;

    public void Repel()
    {
        transform.DOLocalMove(endPosition, duration, false);
    }

    public void Comeback()
    {
        transform.DOLocalMove(startPosition, duration, false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Repel();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Comeback();
    }
}
