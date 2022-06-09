using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{



    public AudioSource collectSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        GameManager.berriesCollected ++;
        //MainCountdown.secondsLeft += 2;

        Destroy(gameObject);
    }
}
