using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{

    private TransitionScript transitionRef;

    private void Start()
    {
        transitionRef = FindObjectOfType<TransitionScript>();
    }
    private void OnTriggerEnter(Collider other) //hitting this sphere will cause transition to occur
    {
        if (other.tag == "Player")
        {
            transitionRef.SwipeToLevel();
        }
    }

}
