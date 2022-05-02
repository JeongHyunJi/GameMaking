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
            inventorys.UseInvent(1);
            inventorys.UseCoins(1);
        }
        else if (BtnName == "item2") //������
        {
            inventorys.GetInvent(2);
            inventorys.GetCoins(3);
        }
        else if (BtnName == "item3") //�ȱ����� ��
        {
            inventorys.GetInvent(3);
            inventorys.GetCoins(5);
        }
        else if (BtnName == "item4") //�߱����� ��
        {
            inventorys.GetInvent(4);
            inventorys.GetCoins(10);
        }
        else if (BtnName == "item5") //ź ��
        {
            inventorys.GetInvent(5);
            inventorys.GetCoins(3);
        }
    }
}
