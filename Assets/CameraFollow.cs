using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    public float yOffset = 0f;
    Vector3 position;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float newPositionY = Mathf.Clamp(player.position.y, 0 + yOffset, 24f);
        position = new Vector3(transform.position.x, newPositionY, transform.position.z);
        transform.position = position;
    }
}
