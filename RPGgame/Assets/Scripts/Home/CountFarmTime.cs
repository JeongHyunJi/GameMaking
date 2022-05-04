using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;



public class CountFarmTime : MonoBehaviour
{
    public static FarmTimeController[] farmTimeControllers = new FarmTimeController[6];
    static bool[] ClickCheck = { false, false, false, false, false, false };
    int cur = 0;

    public GameObject savePlayer;
    private GameObject ThisButton;

    private void Awake()
    {
        if (TimeController.isStart)
        {
            farmTimeControllers[0] = GameObject.FindGameObjectsWithTag("Farm")[0].GetComponent<FarmTimeController>();
            farmTimeControllers[1] = GameObject.FindGameObjectsWithTag("Farm")[1].GetComponent<FarmTimeController>();
            farmTimeControllers[2] = GameObject.FindGameObjectsWithTag("Farm")[2].GetComponent<FarmTimeController>();
            farmTimeControllers[3] = GameObject.FindGameObjectsWithTag("Farm")[3].GetComponent<FarmTimeController>();
            farmTimeControllers[4] = GameObject.FindGameObjectsWithTag("Farm")[4].GetComponent<FarmTimeController>();
            farmTimeControllers[5] = GameObject.FindGameObjectsWithTag("Farm")[5].GetComponent<FarmTimeController>();
        }
    }
    public void BtnClick()
    {
        ThisButton = EventSystem.current.currentSelectedGameObject;

        cur = (int)ThisButton.name[4] - 48;
        //�̺κ� ���� �ʿ�
        if (farmTimeControllers[cur].score == 24)
        {
            savePlayer.GetComponent<SavePlayer>().GetCorn();
        }
        else if (farmTimeControllers[cur].score == 0)
        {
            ClickCheck[cur] = true;
            farmTimeControllers[cur].stTime = DateTime.Now;
            PlayerPrefs.SetString("BtnClickTime" + cur, farmTimeControllers[cur].stTime.ToString());
        }
        else
        {
            Reset(cur);
        }
        farmTimeControllers[cur].score = 0;
    }

    public void Reset(int i)
    {
        farmTimeControllers[i].diffSec = -1;
        ClickCheck[i] = false;
    }

    public void Update()
    {
        for (int i=0;i<6;i++) {
            //Button�� Ŭ���� ���
            if (ClickCheck[i] == true)
            {
                //start time ����
                string ClickTime = PlayerPrefs.GetString("BtnClickTime"+i);
                farmTimeControllers[i].stTime = Convert.ToDateTime(ClickTime);

                //current time ����
                farmTimeControllers[i].curTime = DateTime.Now;

                //current time�� start time�� ���� ����
                TimeSpan timeDiff = farmTimeControllers[i].curTime - farmTimeControllers[i].stTime;
                farmTimeControllers[i].totalMin = timeDiff.TotalMinutes;
                farmTimeControllers[i].diffHour = timeDiff.Hours;
                farmTimeControllers[i].diffMin = timeDiff.Minutes;
                farmTimeControllers[i].diffSec = timeDiff.Seconds;
                //�ð����� ���� Score ���
                //if (farmTimeControllers[i].diffHour == 0 && farmTimeControllers[i].diffMin == 0)
                //{
                    if (farmTimeControllers[i].totalMin >= 25)
                    {
                        Reset(i);
                    }
                    else
                    {
                        farmTimeControllers[i].score=(int)farmTimeControllers[i].totalMin;
                    }
                //}
            }
        }

    }
}