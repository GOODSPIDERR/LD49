using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScriptedMagnet : MonoBehaviour
{
    public Transform leftPoint, rightPoint;
    Vector3 leftPosition, rightPosition;
    public int state = 0; //Off is 0, left is 1, right is 2
    MagnetMoment magnetMoment;
    void Start()
    {
        leftPosition = leftPoint.position;
        rightPosition = rightPoint.position;
        magnetMoment = GetComponent<MagnetMoment>();
    }

    void Update()
    {
        if (magnetMoment.magnetised && magnetMoment.lever)
        {
            transform.DOMove(leftPosition, 1f).OnComplete(() => state = 1);
        }
    }
}
