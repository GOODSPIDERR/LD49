using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainDoor : MonoBehaviour
{
    public ScriptedMagnet scriptedMagnet;
    bool doorOpened;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scriptedMagnet.state == 1 && !doorOpened)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        doorOpened = true;
        transform.DOShakePosition(1, 0.25f, 50, 90).OnComplete(() => transform.DOMove(new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), 2));
        transform.DOShakePosition(2, 0.25f, 50, 90);
    }
}
