using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;
    public int maxLives = 3;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Lives();

    }

    public void Lives()
    {
        if (maxLives == 3)
        {
            live1.SetActive(true);
            live2.SetActive(true);
            live3.SetActive(true);
        }

        if (maxLives == 2)
        {
            live1.SetActive(true);
            live2.SetActive(true);
            live3.SetActive(false);
        }

        if (maxLives == 1)
        {
            live1.SetActive(true);
            live2.SetActive(false);
            live3.SetActive(false);
        }

        if (maxLives <= 0)
        {
            SceneManager.LoadScene("DungeonArea", LoadSceneMode.Single);
        }

        if(maxLives >= 3)
        {
            maxLives = 3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.gameObject.tag == "Traps")
        {
            maxLives -= 1;
            audio.Play();
        }

        if(other.gameObject.tag == "Potions")
        {
            maxLives += 1;
        }
    }


}
