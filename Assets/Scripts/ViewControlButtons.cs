using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewControlButtons : MonoBehaviour
{
    public GameObject joystickPanel;
    public GameObject keyboardPanel;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextButton()
    {
        if(joystickPanel)
        {
            joystickPanel.SetActive(false);
            keyboardPanel.SetActive(true);
        }
        
    }

    public void PreviousButton()
    {
        if(keyboardPanel)
        {
            joystickPanel.SetActive(true);
            keyboardPanel.SetActive(false);
        }
        
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level01", LoadSceneMode.Single);
    }

}
