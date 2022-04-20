using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    public GameObject GameManager;
    int[] invent;

    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;

        //SavePlayer���� ��������
        SavePlayer inventorys = FindObjectOfType<SavePlayer>();
        invent = inventorys.ReturnInvent();

        if (BtnName == "item1") //����
        {
            Debug.Log("1�����: "+invent[0]);
            inventorys.UseInvent(1);
            Debug.Log("1�����:"+invent[0]);

        }
        else if (BtnName == "item2") //������
        {
            Debug.Log("2�߰���: " + invent[1]);
            inventorys.GetInvent(2);
            Debug.Log("2�߰���:" + invent[1]);
        }
        else if (BtnName == "item3") //�ȱ����� ��
        {
            Debug.Log("3�߰���: " + invent[2]);
            inventorys.GetInvent(3);
            Debug.Log("3�߰���:" + invent[2]);
        }
        else if (BtnName == "item4") //�߱����� ��
        {
            Debug.Log("4�߰���: " + invent[3]);
            inventorys.GetInvent(4);
            Debug.Log("4�߰���:" + invent[3]);
        }
        else if (BtnName == "item5") //ź ��
        {
            Debug.Log("5�߰���: " + invent[4]);
            inventorys.GetInvent(5);
            Debug.Log("5�߰���:" + invent[4]);
        }
    }
}
