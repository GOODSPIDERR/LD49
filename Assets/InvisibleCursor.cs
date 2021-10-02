using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCursor : MonoBehaviour
{
    Vector3 worldPosition;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane + 4;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = worldPosition;
    }
}
