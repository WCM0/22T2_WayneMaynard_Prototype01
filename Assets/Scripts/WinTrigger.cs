using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    public GameObject winMessage;
    public GameObject counterText;
    public GameObject counterTimer;

    void OnTriggerEnter(Collider other)
    {
        
        
        winMessage.SetActive(true);
        counterText.SetActive(false);
        counterTimer.SetActive(false);
       
        
    }
}
