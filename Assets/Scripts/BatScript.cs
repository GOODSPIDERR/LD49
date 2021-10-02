using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    //This is the script where the bat prefabs will take damage, instantiate death vfx and play dying sound

    private int currentHealth;
    public GameObject dyingVFX;
    private AudioSource batSound;

    public void Start()
    {
        currentHealth = 1;
        batSound = GetComponent<AudioSource>();
    }
    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called. This could be called elsewhere as well

        currentHealth -= damageAmount; //health decrease with each hit. 
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false); //if health falls below zero, make it disappear
            GameObject clone;
            clone = Instantiate(dyingVFX, new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z), transform.rotation) as GameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magnet") 
        {
            batSound.Play();
            Damage(1);
        }
    }
}
