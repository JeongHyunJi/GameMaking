using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class FarmTimeController
{
    public static DateTime stTime;
    public static DateTime curTime;
    public static int diffHour;
    public static int diffMin;
    public static int diffSec;

    //�۹� ��Ȯ�ϱ�
    public static int crop;
}

public class CountFarmTime : MonoBehaviour
{
    public Text textTimer;
    bool ClickCheck = false;
    int[] Check = { 0, 0, 0, 0, 0, 0 }; //�ð� �ߺ� üũ

    public void BtnClick()
    {
        ClickCheck = true;
        FarmTimeController.stTime = DateTime.Now;
        PlayerPrefs.SetString("BtnClickTime", FarmTimeController.stTime.ToString());
    }

    public void Reset()
    {
        FarmTimeController.crop++;
        ClickCheck = false;
        ScoreCount.Score = 0;
        for(int i=0; i<6; i++)
        {
            Check[i] = 0;
        }
        FarmTimeController.diffSec = -1;
    }

    public void FixedUpdate()
    {
        //Button�� Ŭ���� ���
        if (ClickCheck == true)
        {
            //start time ����
            string ClickTime = PlayerPrefs.GetString("BtnClickTime");
            FarmTimeController.stTime = Convert.ToDateTime(ClickTime);

            //current time ����
            FarmTimeController.curTime = DateTime.Now;

            //current time�� start time�� ���� ����
            TimeSpan timeDiff = FarmTimeController.curTime - FarmTimeController.stTime;
            FarmTimeController.diffHour = timeDiff.Hours;
            FarmTimeController.diffMin = timeDiff.Minutes;
            FarmTimeController.diffSec = timeDiff.Seconds;

            //�ð����� ���� Score ���
            if (FarmTimeController.diffHour == 0 && FarmTimeController.diffMin==0)
            {
                switch (FarmTimeController.diffSec)
                {
                    case 1:
                        if (Check[0] == 0)
                        {
                            ScoreCount.Score++;
                            Check[0] = 1;
                        }
                        break;
                    case 2:
                        if (Check[1] == 0)
                        {
                            ScoreCount.Score++;
                            Check[1] = 1;
                        }
                        break;
                    case 3:
                        if (Check[2] == 0)
                        {
                            ScoreCount.Score++;
                            Check[2] = 1;
                        }
                        break;
                    case 4:
                        if (Check[3] == 0)
                        {
                            ScoreCount.Score++;
                            Check[3] = 1;
                        }
                        break;
                    case 5:
                        if (Check[4] == 0)
                        {
                            ScoreCount.Score++;
                            Check[4] = 1;
                        }
                        break;
                    case 6:
                        if (Check[5] == 0)
                        {
                            ScoreCount.Score++;
                            Check[5] = 1;
                        }
                        break;
                    case 7:
                        Reset();
                        break;
                    default:
                        break;
                }
            }

            //Ȯ��
            textTimer.text = FarmTimeController.curTime.ToString("hh:mm:ss");
        }
    }
}