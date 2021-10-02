using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MagneticBall : MonoBehaviour
{
    Transform invisibleCursor;
    Rigidbody hatMagnet;
    CharacterMovement characterMovement;
    GameObject character;
    bool isBeingDestroyed;
    private void Start()
    {
        invisibleCursor = GameObject.FindGameObjectWithTag("Cursor").transform;
        character = GameObject.FindGameObjectWithTag("Player");
        characterMovement = character.GetComponent<CharacterMovement>();
        hatMagnet = GameObject.FindGameObjectWithTag("Hat").GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!isBeingDestroyed)
        {
            Vector3 distance = transform.position - invisibleCursor.position;
            float newScale = Mathf.Clamp(distance.magnitude, 0.01f, 10f);
            transform.localScale = new Vector3(newScale, newScale, 0.1f);
        }

        if (Input.GetMouseButtonUp(1))
        {
            isBeingDestroyed = true;
            transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() => Destroy(gameObject, 3));
        }
        /*
                if (Input.GetKeyDown(KeyCode.Space) && !isBeingDestroyed)
                {
                    isBeingDestroyed = true;
                    transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 0.2f).OnComplete(() => Destroy(gameObject, 3));
                    characterMovement.Jump();
                }
                */
    }

}
