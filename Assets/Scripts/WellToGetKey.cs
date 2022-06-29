using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WellToGetKey : MonoBehaviour
{
    public GameObject depositPanel;
    public GameObject player;
    public GameObject keyDungeon;
    public GameObject collectiblePanel;
    public AudioSource completedTask;


    // Start is called before the first frame update
    void Start()
    {
        depositPanel.SetActive(false);
        //keyDungeon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if(GameManager.berriesCollected == 8 && GameManager.gemsCollected == 3 && GameManager.coinsCollected == 5)
        {
            Debug.Log("You have all the requirements for the key");
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            depositPanel.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager.berriesCollected == 8 && GameManager.gemsCollected == 3 && GameManager.coinsCollected == 5)
                {
                    Debug.Log("You have all the requirements for the key");
                    keyDungeon.SetActive(true);
                    completedTask.Play();
                } else
                {
                    Debug.Log("You don't have enough materials");
                    collectiblePanel.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            depositPanel.SetActive(false);
            collectiblePanel.SetActive(false);
        }
    }

}
