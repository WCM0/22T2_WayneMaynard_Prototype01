using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMPro.TMP_Text textMeshPro;

    public static int berriesCollected;

    public GameObject goToWizardText;

    public GameObject collectObjectiveText;

    public GameObject castleGate;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = "" + berriesCollected;
        goToWizardText.SetActive(false);
        castleGate.SetActive(false);
        collectObjectiveText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "" + berriesCollected;

        if (berriesCollected == 10 && MainCountdown.secondsLeft >= 0)
        {
            //Debug.Log("Take the berries to the Wizard");
            collectObjectiveText.SetActive(false);
            goToWizardText.SetActive(true);
            castleGate.SetActive(true);
        }

        if (MainCountdown.secondsLeft == 0)
        {
            //Debug.Log("Time's Up!");
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);

        }
    }
}