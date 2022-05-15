using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePlayer : MonoBehaviour
{
    private static string playerName; //�� ������ ���� �ʱ�ȭ �Ǵ� ���� �����ϱ� ���� static���� ���� ����
    private static int coin;
    private static int[] inventory = new int[8]; //����, ������, ��(������), ��(������), ��(Ž)
    private static string times;
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
                DateTime startDate = new DateTime(1900, 1, 1, 9, 0, 0);
                times = startDate.ToString(); //yyyy,mm,dd,hh,mm -> �ʱ⼼�� : 1900/1/1/ am 9:00 
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
                times = PlayerPrefs.GetString("saved_time");
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
        inventory = new int[] { 1, 2, 1, 1, 1, 0, 0, 0 };
        DateTime startDate = new DateTime(1900, 1, 1, 9, 0, 0);
        times = startDate.ToString(); //yyyy,mm,dd,hh,mm -> �ʱ⼼�� : 1900/1/1/ am 9:00 
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

    public void GetHeart()
    {
        if (Hearts.heart == 5)
        {
            Debug.Log("��Ʈ Ǯ���� �Ϸ�!");
        }
        else
        {
            Hearts.heart++;
        }
    }
    public int ReturnHeart()
    {
        return Hearts.heart;
    }
    //coin
    public void GetCoins(int num)
    {
        coin += num;
    }
    public void GetCoinCheat()
    {
        coin += 10;
    }
    public int UseCoins(int num)
    {
        if (coin - num < 0)
        {
            Debug.Log("coin ��� �Ұ�");
            return -1;
        }
        else
        {
            coin -= num;
            return 0;
        }
    }
    public int ReturnCoins()
    {
        return coin;
    }

    //time
    public DateTime ReturnTime()
    {
        DateTime tmpTime = Convert.ToDateTime(times);
        return tmpTime;
    }

    //inventory
    public int UseInvent(int num)
    {
        if(inventory[num - 1] == 0)
        {
            Debug.Log("inventory ��� �Ұ�");
            return -1;
        }
        else
        {
            inventory[num - 1]--;
            return 0;
        }
    }
    public void UseCorn()
    {
        inventory[1] -= 2;
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
        PlayerPrefs.SetString("saved_time", TimeController.time.ToString());
        PlayerPrefs.SetInt("saved_hearts", Hearts.heart);
        PlayerPrefs.Save();
    }
}
