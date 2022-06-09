using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainCountdown : MonoBehaviour
{
    
    public TMPro.TMP_Text textMeshPro;
    //public GameObject gameOverText;

    public static int secondsLeft = 30;
    public bool takingAway = false;



    // Start is called before the first frame update
    void Start()
    {
        //gameCountdown.GetComponent<Text>().text = "" + secondsLeft;
        textMeshPro.text = "" + secondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
        else if (takingAway == false && secondsLeft < 1)
        {
            //gameCountdown.GetComponent<Text>().text = "XX";
            //gameOverText.GetComponent<Text>().text = "GAME OVER";

            //buttonPanel.SetActive(true);
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        //gameCountdown.GetComponent<Text>().text = "" + secondsLeft;
        textMeshPro.text = "" + secondsLeft;
        takingAway = false;

    }


}
