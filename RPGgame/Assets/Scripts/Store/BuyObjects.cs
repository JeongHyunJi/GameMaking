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

        //----------------------- ����
        if (BtnName == "seed") //����
        {
            inventorys.GetInvent(1);
            inventorys.UseCoins(30);
        }
        else if (BtnName == "heart") //��Ʈ
        {
            inventorys.GetHeart();
            inventorys.UseCoins(300);
        } //----------------------- �Ǹ�
        else if (BtnName == "corn") //������
        {
            inventorys.UseInvent(2);
            inventorys.GetCoins(50);
        }
        else if (BtnName == "bread_not") //�ȱ����� ��
        {
            inventorys.UseInvent(3);
            inventorys.GetCoins(70);
        }
        else if (BtnName == "bread_well") //�߱����� ��
        {
            inventorys.UseInvent(4);
            inventorys.GetCoins(130);
        }
        else if (BtnName == "bread_burn") //ź ��
        {
            inventorys.UseInvent(5);
            inventorys.GetCoins(40);
        }
        else if (BtnName == "fish_s") //���� �����
        {
            inventorys.UseInvent(6);
            inventorys.GetCoins(10);
        }
        else if (BtnName == "fish_m") //�߰� �����
        {
            inventorys.UseInvent(7);
            inventorys.GetCoins(20);
        }
        else if (BtnName == "fish_l") //ū �����
        {
            inventorys.UseInvent(8);
            inventorys.GetCoins(30);
        }
    }
}
