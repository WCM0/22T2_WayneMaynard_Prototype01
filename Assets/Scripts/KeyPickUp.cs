using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public AudioSource collectSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();

        GameManager.keyCollected++;
        //MainCountdown.secondsLeft += 2;


        Destroy(gameObject);
    }

}
