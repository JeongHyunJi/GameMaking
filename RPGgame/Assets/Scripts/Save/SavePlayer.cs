using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    private static string playerName; //매 씬마다 값이 초기화 되는 것을 방지하기 위해 static으로 변수 선언
    private static int coin;
    private static int[] inventory = new int[5]; //씨앗, 옥수수, 빵(안익음), 빵(잘익음), 빵(탐)
    private static int[] times = new int[5];

    private bool IsSave;
    // Start is called before the first frame update
    void Awake()
    {
        IsSave = PlayerPrefs.HasKey("saved_name");
        if (TimeController.isStart) //  한번만 실행되도록 if문 안에 코드 작성
        {
            if (!IsSave)
            {
                Debug.Log("저장된 데이터가 없습니다.");
                playerName = "guest"; //나중에 입력받도록 수정
                coin = 5;
                inventory = new int[] { 1, 1, 1, 1, 1 };
                times = new int[] { 1900, 1, 1, 9, 0 }; //yyyy,mm,dd,hh,mm -> 초기세팅 : 1900/1/1/ am 9:00 
                Debug.Log(coin);
            }
            else
            {
                Debug.Log("저장된 데이터가 있습니다.");
                playerName = PlayerPrefs.GetString("saved_name");
                coin = PlayerPrefs.GetInt("saved_coin");
                inventory[0] = PlayerPrefs.GetInt("saved_1"); //inventory의 내용물의 개수를 저장
                inventory[1] = PlayerPrefs.GetInt("saved_2");
                inventory[2] = PlayerPrefs.GetInt("saved_3");
                inventory[3] = PlayerPrefs.GetInt("saved_4");
                inventory[4] = PlayerPrefs.GetInt("saved_5");
                times[0] = PlayerPrefs.GetInt("saved_year");
                times[1] = PlayerPrefs.GetInt("saved_month");
                times[2] = PlayerPrefs.GetInt("saved_day");
                times[3] = PlayerPrefs.GetInt("saved_hour");
                times[4] = PlayerPrefs.GetInt("saved_minite");

            }
        }
    }
    // Update is called once per frame
    public string GetName()
    {
        return playerName;
    }
    public void SetName(string newName)
    {
        playerName = newName;

    }
    public void GetCorn()
    {
        inventory[1]++;
    }
    public void GetCoins(int num)
    {
        coin += num;
    }

    public void UseCoins(int num) 
    {
        coin -= num;
    }
    public int ReturnCoins()
    {
        Debug.Log(coin);
        return coin;
    }

    public DateTime ReturnTime()
    {
        DateTime tmpTime = new DateTime(times[0], times[1], times[2], times[3], times[4], 0);
        return tmpTime;
    }

    public int[] ReturnInvent()
    {
        return inventory;
    }

    public int ReturnInvent4()
    {
        return inventory[3];
    }

    public int ReturnInvent5()
    {
        return inventory[4];
    }

    public void SaveContent()
    {
        PlayerPrefs.SetString("saved_name", playerName);
        PlayerPrefs.SetInt("saved_coin", coin);
        PlayerPrefs.SetInt("saved_1", inventory[0]);
        PlayerPrefs.SetInt("saved_2", inventory[1]);
        PlayerPrefs.SetInt("saved_3", inventory[2]);
        PlayerPrefs.SetInt("saved_4", inventory[3]);
        PlayerPrefs.SetInt("saved_5", inventory[4]);
        PlayerPrefs.SetInt("saved_year", TimeController.time.Year);
        PlayerPrefs.SetInt("saved_month", TimeController.time.Month);
        PlayerPrefs.SetInt("saved_day", TimeController.time.Day);
        PlayerPrefs.SetInt("saved_hour", TimeController.time.Hour);
        PlayerPrefs.SetInt("saved_minite", TimeController.time.Minute);
        PlayerPrefs.Save();
    }
}
