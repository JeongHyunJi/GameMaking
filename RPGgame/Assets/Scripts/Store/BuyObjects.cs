using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{

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
    }

    private void Update()
    {
        coinText.text = inventorys.ReturnCoins() + " $";
    }
    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(BtnName);

        //****************************��ư�̸� �� ����***************//
        //----------------------- ����
        if (BtnName == "seed_btn") //����
        {
            inventorys.GetInvent(1);
            inventorys.UseCoins(30);
        }
        else if (BtnName == "heart_btn") //��Ʈ
        {
            inventorys.GetHeart();
            inventorys.UseCoins(300);
        } //----------------------- �Ǹ�
        else if (BtnName == "corn_btn") //������
        {
            inventorys.UseInvent(2);
            inventorys.GetCoins(50);
        }
        else if (BtnName == "notBread_btn") //�ȱ����� ��
        {
            inventorys.UseInvent(3);
            inventorys.GetCoins(70);
        }
        else if (BtnName == "wellBread_btn") //�߱����� ��
        {
            inventorys.UseInvent(4);
            inventorys.GetCoins(130);
        }
        else if (BtnName == "burnBread_btn") //ź ��
        {
            inventorys.UseInvent(5);
            inventorys.GetCoins(40);
        }
        else if (BtnName == "Sfish_btn") //���� �����
        {
            inventorys.UseInvent(6);
            inventorys.GetCoins(10);
        }
        else if (BtnName == "Mfish_btn") //�߰� �����
        {
            inventorys.UseInvent(7);
            inventorys.GetCoins(20);
        }
        else if (BtnName == "Lfish_btn") //ū �����
        {
            inventorys.UseInvent(8);
            inventorys.GetCoins(30);
        }
    }
    public void ClickLeftBtn()
    {
        Debug.Log("clickleft");
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
