using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonDoor : MonoBehaviour
{
    public GameObject openPanel;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        openPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            openPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager.keyCollected == 1)
                {
                    Debug.Log("You have all the requirements for the key");
                    SceneManager.LoadScene("DungeonArea");
                }
                else
                {
                    Debug.Log("You don't have the key");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            openPanel.SetActive(false);
        }
    }

}
