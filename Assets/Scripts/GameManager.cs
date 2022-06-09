using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMPro.TMP_Text textMeshPro;

    public static int berriesCollected;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = "" + berriesCollected;

    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "" + berriesCollected;

        if (berriesCollected == 10 && MainCountdown.secondsLeft >= 0)
        {
            Debug.Log("Take the berries to the Wizard");
        }

        if (MainCountdown.secondsLeft == 0)
        {
            Debug.Log("Time's Up!");
        }
    }
}