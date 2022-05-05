using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;

        //SavePlayer���� ��������
        SavePlayer inventorys = FindObjectOfType<SavePlayer>();

        if (BtnName == "item1") //����
        {
            inventorys.GetInvent(1);
            inventorys.UseCoins(1);
        }
        else if (BtnName == "item2") //������
        {
            inventorys.UseInvent(2);
            inventorys.GetCoins(3);
        }
        else if (BtnName == "item3") //�ȱ����� ��
        {
            inventorys.UseInvent(3);
            inventorys.GetCoins(5);
        }
        else if (BtnName == "item4") //�߱����� ��
        {
            inventorys.UseInvent(4);
            inventorys.GetCoins(10);
        }
        else if (BtnName == "item5") //ź ��
        {
            inventorys.UseInvent(5);
            inventorys.GetCoins(3);
        }
    }
}
