using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parameterCheck : MonoBehaviour
{

    // Update is called once per frame
    private float currentBreaths, currentSessions;

    void Update()
    {
        if (MainMenu.breathsNo > 0 && MainMenu.sessionsNo > 0)
        {
            currentBreaths = MainMenu.breathsNo;
            currentSessions = MainMenu.sessionsNo;

            PlayerPrefs.SetFloat("lastStoredBreaths", currentBreaths);
            PlayerPrefs.SetFloat("lastStoredSessions", currentSessions);

            MainMenu.canPlayGame = true;
        }
        else
        {
            MainMenu.canPlayGame = false;    
        }
    }
}
