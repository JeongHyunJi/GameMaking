using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public static class TimeController
{
    public static DateTime time = DateTime.Now;
    
    public static void TimeCount()
    {
        time = time.AddSeconds(1);
    }
}

public class CountPlayTime : MonoBehaviour
{
    public Text textTimer;

    //ó�� ���� �ð��� ī��Ʈ �� �� �ֵ���
    //public string check = "None";

    //void Start()
    //{
    //    //set start time
    //    if (SceneManager.GetActiveScene().name == "Home")
    //    {
    //        if (check != "Complete")
    //        {
    //            DateTime startTime = DateTime.Now;
    //            PlayerPrefs.SetString("stTime_1", startTime.ToString());
    //            check = "Complete";
    //        }
    //    }
    //}
    //void Update()
    //{
    //    string timeStr = PlayerPrefs.GetString("stTime_1");
    //    DateTime startTime = Convert.ToDateTime(timeStr);
        
    //    //update current time
    //    DateTime currentTime = DateTime.Now;
    //    TimeSpan timeDiff = currentTime - startTime;

    //    //int diffMinute = timeDiff.Minutes;
    //    int diffSecond = timeDiff.Seconds;

    //    textTimer.text = "�� ����: " + diffSecond.ToString();
    //}

    private void FixedUpdate()
    {
        TimeController.TimeCount();
        textTimer.text = "time " + TimeController.time.ToString("yyyy�� MM�� dd��\n tt hh:mm");
    }
}