using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    private static string playerName; //�� ������ ���� �ʱ�ȭ �Ǵ� ���� �����ϱ� ���� static���� ���� ����
    private static int coin;
    private static int[] inventory = new int[8]; //����, ������, ��(������), ��(������), ��(Ž)
    private static int[] times = new int[5];
    private bool IsSave;
    // Start is called before the first frame update
    void Awake()
    {
        IsSave = PlayerPrefs.HasKey("saved_name");
        if (TimeController.isStart) //  �ѹ��� ����ǵ��� if�� �ȿ� �ڵ� �ۼ�
        {
            if (!IsSave)
            {
                Debug.Log("����� �����Ͱ� �����ϴ�.");
                playerName = "guest"; //���߿� �Է¹޵��� ����
                coin = 5;
                inventory = new int[] { 1, 1, 1, 1, 1, 0, 0, 0 };
                times = new int[] { 1900, 1, 1, 9, 0 }; //yyyy,mm,dd,hh,mm -> �ʱ⼼�� : 1900/1/1/ am 9:00 
                Hearts.heart = 5;
            }
            else
            {
                Debug.Log("����� �����Ͱ� �ֽ��ϴ�.");
                playerName = PlayerPrefs.GetString("saved_name");
                coin = PlayerPrefs.GetInt("saved_coin");
                inventory[0] = PlayerPrefs.GetInt("saved_1"); //inventory�� ���빰�� ������ ���� // ����
                inventory[1] = PlayerPrefs.GetInt("saved_2"); // ������
                inventory[2] = PlayerPrefs.GetInt("saved_3"); // ������ ��
                inventory[3] = PlayerPrefs.GetInt("saved_4"); // ���� ��
                inventory[4] = PlayerPrefs.GetInt("saved_5"); // ź ��
                inventory[5] = PlayerPrefs.GetInt("saved_6"); // ���� �����
                inventory[6] = PlayerPrefs.GetInt("saved_7"); // �߰� �����
                inventory[7] = PlayerPrefs.GetInt("saved_8"); // ū �����
                times[0] = PlayerPrefs.GetInt("saved_year");
                times[1] = PlayerPrefs.GetInt("saved_month");
                times[2] = PlayerPrefs.GetInt("saved_day");
                times[3] = PlayerPrefs.GetInt("saved_hour");
                times[4] = PlayerPrefs.GetInt("saved_minite");
                Hearts.heart = PlayerPrefs.GetInt("saved_hearts");
            }
        }
    }
    // Update is called once per frame

    public void startNewGame(string newName)
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("newgame name: "+newName);
        playerName = newName;
        coin = 5;
        inventory = new int[] { 1, 1, 1, 1, 1, 0, 0, 0 };
        times = new int[] { 1900, 1, 1, 9, 0 }; //yyyy,mm,dd,hh,mm -> �ʱ⼼�� : 1900/1/1/ am 9:00 
        Hearts.heart = 5;
    }

    public bool IsSaveExist()
    {
        return IsSave;
    }

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

    //coin
    public void GetCoins(int num)
    {
        coin += num;
    }
    public void UseCoins(int num) 
    {
        if (coin - num <= 0)
        {
            Debug.Log("coin ��� �Ұ�");
        }
        else
        {
            coin -= num;
        }
    }
    public int ReturnCoins()
    {
        return coin;
    }

    //time
    public DateTime ReturnTime()
    {
        DateTime tmpTime = new DateTime(times[0], times[1], times[2], times[3], times[4], 0);
        return tmpTime;
    }

    //inventory
    public void UseInvent(int num)
    {
        if(inventory[num - 1] == 0)
        {
            Debug.Log("inventory��� �Ұ�");
        }
        else
        {
            inventory[num - 1]--;
        }
    }
    public void GetInvent(int num)
    {
        inventory[num - 1]++;
    }
    public int[] ReturnInvent()
    {
        return inventory;
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
        PlayerPrefs.SetInt("saved_6", inventory[5]);
        PlayerPrefs.SetInt("saved_7", inventory[6]);
        PlayerPrefs.SetInt("saved_8", inventory[7]);
        PlayerPrefs.SetInt("saved_year", TimeController.time.Year);
        PlayerPrefs.SetInt("saved_month", TimeController.time.Month);
        PlayerPrefs.SetInt("saved_day", TimeController.time.Day);
        PlayerPrefs.SetInt("saved_hour", TimeController.time.Hour);
        PlayerPrefs.SetInt("saved_minite", TimeController.time.Minute);
        PlayerPrefs.SetInt("saved_hearts", Hearts.heart);
        PlayerPrefs.Save();
    }
}
