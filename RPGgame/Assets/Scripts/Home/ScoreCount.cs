using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreCount : MonoBehaviour
{
    public static int Score = 0;
    public Text scoreText;
    public GameObject button;

    DateTime StartTime = DateTime.Now;
    //DateTime EndDate = StartDate.AddDays(+1);
    //TimeSpan timeCal = EndDate - StartDate;
    //int timeCalMinute = timeCal.Minutes;
    //PlayerPrefs.SetString("stTime_1",StartTime.ToString());
    //PlayerPrefs.SetString("stTime_1",StartTime.)
    //string timeStr = PlayerPrefs.GetString("stTime_1");
    //DateTime CurrentTime = DateTime.Now;
    //TimeSpan timeDif = currentTime - startTime;
    

    void Update()
    {
        if (Score == 0)
        {
            scoreText.text = "First Time";
        }
        else if (0 < Score && Score < 6)
        {
            scoreText.text = Score + " Time";
            //scoreText.text = timeDif;
        }
        else
        {
            scoreText.text = "We get a Corn!";
        }
    }

    public void ScoreUp()
    {
        Score++;
    }
}
