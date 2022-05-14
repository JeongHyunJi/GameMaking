using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    public GameObject CheckPanel;
    public GameObject Alarm;
    public Text CheckText;
    public Text AlarmText;
    string ObjectName = "nothing";
    public void OffAlarm()
    {
        Alarm.SetActive(false);
    }

    private SavePlayer inventorys;
    public Text coinText;
    public GameObject[] setOne;
    public GameObject[] setTwo;
    private void Start()
    {
        inventorys = FindObjectOfType<SavePlayer>();
        for(int i = 0; i < setTwo.Length; i++)
        {
            setTwo[i].SetActive(false);
        }
        OffAlarm();
        CheckPanel.SetActive(false);
    }

    private void Update()
    {
        coinText.text = inventorys.ReturnCoins() + " $";
    }

    private void PrintAlarm(int use,string type)
    {
        if (use == -1)
        {
            Alarm.SetActive(true);
            if(type=="coin")
                AlarmText.text = "Not Enough Coin!";
            if(type=="inv")
                AlarmText.text = "Not Enough Stock!";
            Invoke("OffAlarm", 2f);
        }
    }

    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        ObjectName = BtnName.Substring(0, BtnName.Length - 4);
        if (ObjectName == "seed" || ObjectName == "heart")
            CheckText.text = "Do  you  want  to \nbuy  " + ObjectName + "?";
        else
            CheckText.text = "Do  you  want  to \nsell  " + ObjectName + "?";
        CheckPanel.SetActive(true);
    }
    public void ClickIsOk()
    {
        string BtnOkName = EventSystem.current.currentSelectedGameObject.name;
        if (BtnOkName== "OkBtn")
        {
            int use;
            //----------------------- ����
            if (ObjectName == "seed") //����
            {
                inventorys.GetInvent(1);
                use = inventorys.UseCoins(30);
                PrintAlarm(use, "coin");
            }
            else if (ObjectName == "heart") //��Ʈ
            {
                inventorys.GetHeart();
                use = inventorys.UseCoins(300);
                PrintAlarm(use, "coin");
            } //----------------------- �Ǹ�
            else if (ObjectName == "corn") //������
            {
                use = inventorys.UseInvent(2);
                PrintAlarm(use, "inv");
                inventorys.GetCoins(50);
            }
            else if (ObjectName == "notBread") //�ȱ����� ��
            {
                use = inventorys.UseInvent(3);
                PrintAlarm(use, "inv");
                inventorys.GetCoins(70);
            }
            else if (ObjectName == "wellBread") //�߱����� ��
            {
                use = inventorys.UseInvent(4);
                PrintAlarm(use, "inv");
                inventorys.GetCoins(130);
            }
            else if (ObjectName == "burnBread") //ź ��
            {
                use = inventorys.UseInvent(5);
                PrintAlarm(use, "inv");
                inventorys.GetCoins(40);
            }
            else if (ObjectName == "fish(s)") //���� �����
            {
                use = inventorys.UseInvent(6);
                PrintAlarm(use, "inv");
                inventorys.GetCoins(10);
            }
            else if (ObjectName == "fish(m)") //�߰� �����
            {
                use = inventorys.UseInvent(7);
                PrintAlarm(use, "inv");
                inventorys.GetCoins(20);
            }
            else if (ObjectName == "fish(l)") //ū �����
            {
                use = inventorys.UseInvent(8);
                PrintAlarm(use, "inv");
                inventorys.GetCoins(30);
            }
            CheckPanel.SetActive(false);
            ObjectName = "nothing";
        }
        else if (BtnOkName == "CancelBtn")
        {
            CheckPanel.SetActive(false);
            ObjectName = "nothing";
        }
    }
    public void ClickLeftBtn()
    {
        for (int i = 0; i < setOne.Length; i++)
        {
            setOne[i].SetActive(true);
        }
        for (int i = 0; i < setTwo.Length; i++)
        {
            setTwo[i].SetActive(false);
        }
    }
    public void ClickRighttBtn()
    {
        for (int i = 0; i < setOne.Length; i++)
        {
            setOne[i].SetActive(false);
        }
        for (int i = 0; i < setTwo.Length; i++)
        {
            setTwo[i].SetActive(true);
        }
    }
}
