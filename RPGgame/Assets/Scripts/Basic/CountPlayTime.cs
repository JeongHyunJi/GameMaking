using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public static class TimeController
{
    public static DateTime time = new DateTime(1900, 1, 1, 9, 0, 0);
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
    //public GameObject filter;
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

    private void FixedUpdate()
    {
        TimeController.TimeCount();
        if (textTimer)
        {
            textTimer.text = "time " + TimeController.time.ToString("yyyy-MM-dd\n tt h:mm");
        }
    }
}