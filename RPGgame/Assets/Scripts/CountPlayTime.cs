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

    //처음 시작 시간을 카운트 할 수 있도록
    //public string check = "None";

    void Start()
    {
        if (TimeController.isStart)
        {
            TimeController.time = savePlayer.GetComponent<SavePlayer>().ReturnTime();
            TimeController.isStart = false;
        }
    }

    private void FixedUpdate()
    {
        TimeController.TimeCount();
        if (textTimer)
        {
            textTimer.text = "time " + TimeController.time.ToString("yyyy-MM-dd\n tt h:mm");
        }
    }
}