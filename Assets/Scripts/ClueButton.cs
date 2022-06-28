using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueButton : MonoBehaviour
{
    public GameObject cluePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clue()
    {
        if(cluePanel.activeInHierarchy == true)
        {
            cluePanel.SetActive(false);
        } else
        {
            cluePanel.SetActive(true);
        }
    }
}
