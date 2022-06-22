using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMPro.TMP_Text berryText;
    public TMPro.TMP_Text gemText;
    public TMPro.TMP_Text coinText;

    public static int berriesCollected;

    public static int gemsCollected;

    public static int coinsCollected;

    //public GameObject goToWizardText;

    //public GameObject collectObjectiveText;

    //public GameObject castleGate;



    // Start is called before the first frame update
    void Start()
    {

        berryText.text = "" + berriesCollected;
        coinText.text = "" + coinsCollected;
        gemText.text = "" + gemsCollected;
    

    }

// Update is called once per frame
    void Update()
    {
        berryText.text = berriesCollected.ToString() + "/08";
        coinText.text = coinsCollected.ToString() + "/05";
        gemText.text = gemsCollected.ToString() + "/03";

        if (berriesCollected == 8 && gemsCollected == 3 && coinsCollected == 5)
        {
            Debug.Log("You have all the items take them to the castle");
        }

        if (MainCountdown.secondsLeft == 0)
        {
            //Debug.Log("Time's Up!");
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);

        }
    }
}