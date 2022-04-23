using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public static class TimeController
{
    public static DateTime time;
    public static bool isStart = true;

    public static void TimeCount()
    {
        time = time.AddSeconds(1);
    }
}

public class CountPlayTime : MonoBehaviour
{
    public Text textTimer;
    public GameObject savePlayer;

    //ó�� ���� �ð��� ī��Ʈ �� �� �ֵ���
    //public string check = "None";

    void Start()
    {
        if (TimeController.isStart)
        {
            TimeController.time = savePlayer.GetComponent<SavePlayer>().ReturnTime();
            TimeController.isStart = false;
        }
    }

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
        if (textTimer)
        {
            textTimer.text = "time " + TimeController.time.ToString("yyyy�� MM�� dd��\n tt hh:mm");
        }
    }
}