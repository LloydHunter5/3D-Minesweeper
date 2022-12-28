using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Secret : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject secretMode;
    [SerializeField] Game gameGrid;
    int timesQuitHasBeenClicked;
    public void inc()
    {
        timesQuitHasBeenClicked++;
        if(timesQuitHasBeenClicked > 4)
        {
            secretMode.SetActive(true);
        }
    }
    public void setMandelbulbChallenge()
    {
        GlobalConstants.doMandelbulb = true;
        GlobalConstants.isChallengeMode = true;
        gameGrid.reinitialize(26,26, 26, 250);
    }
}
