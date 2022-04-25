using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public GameObject GameManager;
    //��ư
    private int BtnChk = 0;

    //�ð�
    bool btn_active; //��ư Ȱ��ȭ ���� ���� �˻�
    public Text[] text_time; //�ð� ǥ���� text
    public Text btn_text; //���¿� ���� ��ư�� text �����ϱ� ���� text
    float time; //�ð�
    float cooking_time = 4.5f;
    float rest_time = 1.0f;

    //��
    SpriteRenderer sr;
    public GameObject go;

    //��ư Ȱ��ȭ �޼ҵ�
    public void SetTimerOn() 
    {
        btn_active = true;
    }
    //��ư ��Ȱ��ȭ �޼ҵ�
    public void SetTimerOff()
    {
        btn_active = false;
    }

    void Start()
    {
        btn_active = false; //��ư �ʱ� ���� false�� �����
        sr = go.GetComponent<SpriteRenderer>();
    }

    //��ư Ŭ�� �̺�Ʈ
    public void Btn_Click() 
    {
        //SavePlayer���� ��������
        SavePlayer inventorys = FindObjectOfType<SavePlayer>();
        //int[] inv= inventorys.ReturnInvent();
        if (BtnChk == 1)
        {
            SetTimerOff();
        }

        if (!btn_active && BtnChk==0)
        {
            SetTimerOn();
            btn_text.text = "Stop!";
            BtnChk = 1;
            inventorys.UseInvent(2); //������ ���
        }
        else
        {
            SetTimerOff();
            if (cooking_time- rest_time <= time && time <= cooking_time+ rest_time)
            {
                btn_text.text = "<color=#ffe650> Game Complete! </color>";
                Invoke("PrintFinalY", 3f);
                inventorys.GetInvent(4); //���� ��
            }
            else
            {
                btn_text.text = "<color=#68d168> Game Fail.. </color>";
                if (cooking_time - rest_time > time)
                {
                    Invoke("PrintFinalN_Not", 3f);
                    inventorys.GetInvent(3); //���� ���� ��
                }
                else
                {
                    Invoke("PrintFinalN_Burn", 3f);
                    inventorys.GetInvent(5); //ź ��
                }
            }
            time = 0;
            Invoke("SceneChange", 4f);
        }
    }

    public void Update() //�ٲ�� �ð� text�� �ݿ��ϴ� update �����ֱ�
    {
        if (btn_active)
        {
            time += Time.deltaTime;
            if (3.5f <= time && time <= 5.0f)
            {
                text_time[0].text = "Nice Baking!";
                sr.material.color = new Color(0.90f, 0.68f, 0.19f);
            }
            else if (time > 5.0f && time < 7.5f)
            {
                text_time[0].text = "Bread is Burning!";
                sr.material.color = new Color(0.49f, 0.35f, 0.04f);
            }
            else if (time >= 7.5f)
            {
                text_time[0].text = "Bread is All Burned..";
                sr.material.color = new Color(0.0f, 0.0f, 0.0f);
            }
            else
            {
                text_time[0].text = "Baking Now...";
                sr.material.color = new Color(1f, 1f, 1f);
            }
        }
    }

    public void PrintFinalY()
    {
        btn_text.text = "You can get a bread!";
    }
    public void PrintFinalN_Not()
    {
        btn_text.text = "You get a Not Baked Bread!";
    }
    public void PrintFinalN_Burn()
    {
        btn_text.text = "You get a Burned Bread!";
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Home");
        BtnChk = 0;
    }
}