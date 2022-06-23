using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public bool gameStart = false;

    public GameObject startPanel;
    public GameObject healthPanel;
    public GameObject berryDisplayer;
    public GameObject coinDisplayer;
    public GameObject gemDisplayer;

    // Start is called before the first frame update
    void Start()
    {
        if (!gameStart)
        {
            Time.timeScale = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        startPanel.SetActive(false);
        healthPanel.SetActive(true);
        berryDisplayer.SetActive(true);
        coinDisplayer.SetActive(true);
        gemDisplayer.SetActive(true);
        gameStart = true;
    }

}
