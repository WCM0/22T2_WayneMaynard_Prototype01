using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    int _rotationSpeed = 15;

    public AudioSource collectSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        
        //GameManager.berriesCollected ++;
        //MainCountdown.secondsLeft += 2;


        Destroy(gameObject);
    }
}
