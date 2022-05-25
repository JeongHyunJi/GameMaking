using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class CountFarmTime : MonoBehaviour
{
    public static FarmTimeController[] farmTimeControllers = new FarmTimeController[6];
    static bool[] ClickCheck = new bool[6];

    public GameObject savePlayer;
    private GameObject ThisButton;
    private GameObject[] farmList;
    private void Awake()
    {
        if (TimeController.isStart)
        {
            farmList = GameObject.FindGameObjectsWithTag("Farm");
            System.Array.Sort<GameObject>(farmList, (x, y) => string.Compare(x.name, y.name));
            farmTimeControllers[0] = farmList[0].GetComponent<FarmTimeController>();
            farmTimeControllers[1] = farmList[1].GetComponent<FarmTimeController>();
            farmTimeControllers[2] = farmList[2].GetComponent<FarmTimeController>();
            farmTimeControllers[3] = farmList[3].GetComponent<FarmTimeController>();
            farmTimeControllers[4] = farmList[4].GetComponent<FarmTimeController>();
            farmTimeControllers[5] = farmList[5].GetComponent<FarmTimeController>();
            for (int i = 0; i < 6; i++)
            {
                ClickCheck[i] = PlayerPrefs.HasKey("BtnClickTime" + i);
            }
        }
    }
    public void BtnClick()
    {
        ThisButton = EventSystem.current.currentSelectedGameObject;

        int cur = (int)ThisButton.name[4] - 48;
        //�̺κ� ���� �ʿ�
        if (farmTimeControllers[cur].score == 24) //24�� ��� �� => ������ ���� ��
        {
            savePlayer.GetComponent<SavePlayer>().GetCorn();
        }
        else if (farmTimeControllers[cur].score == 0) //�ʱ�ȭ ����
        {
            ClickCheck[cur] = true;
            farmTimeControllers[cur].stTime = DateTime.Now;
            PlayerPrefs.SetString("BtnClickTime" + cur, farmTimeControllers[cur].stTime.ToString());
        }
        else //������ �ʹ� ��
        {
            Reset(cur);
        }
        farmTimeControllers[cur].score = 0;
    }

    public void Reset(int i)
    {
        ClickCheck[i] = false;
        PlayerPrefs.DeleteKey("BtnClickTime" + i);
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
                //�ð����� ���� Score ���
                //if (farmTimeControllers[i].diffHour == 0 && farmTimeControllers[i].diffMin == 0)
                //{
                    if (farmTimeControllers[i].totalMin >= 25)
                    {
                        Reset(i);
                    }
                    else
                    {
                        farmTimeControllers[i].score=(float)farmTimeControllers[i].totalMin;
                    }
                //}
            }
        }

    }
}