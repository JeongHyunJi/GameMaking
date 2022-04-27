using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public static class Hearts
{
    public static int heart = 5;

    public static void HeartControll()
    {
        if (Hearts.heart == 4)
        {
            DateTime stTime = DateTime.Now;
            PlayerPrefs.SetString("Heart_time",stTime.ToString());
        }
        if (Hearts.heart == 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Forest");
        }
    }
}

public class HeartController : MonoBehaviour
{
    public int num;
    public Sprite Lheart;
    public Sprite Dheart;
    Image thisImg;
    // Start is called before the first frame update
    void Start()
    {
        thisImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Hearts.heart);
        if (Hearts.heart < 5)
            HeartsIncrese();
        if (num <= Hearts.heart) 
        {
            thisImg.sprite = Lheart;
        }
        else
        {
            thisImg.sprite = Dheart;
        }
    }

    void HeartsIncrese()
    {
        string ClickTime = PlayerPrefs.GetString("Heart_time");
        DateTime stTime = Convert.ToDateTime(ClickTime);

        //current time ����
        DateTime curTime = DateTime.Now;

        //current time�� start time�� ���� ����
        TimeSpan timeDiff = curTime - stTime;
        if (timeDiff.TotalMinutes > 1 && Hearts.heart < 5) //5�п� �Ѱ��� ����
        {
            Hearts.heart++;
            stTime.AddMinutes(1);
            timeDiff = curTime - stTime;
            PlayerPrefs.SetString("Heart_time", DateTime.Now.ToString());
        }
    }
}