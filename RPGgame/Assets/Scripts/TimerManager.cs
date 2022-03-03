using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    bool btn_active; //��ư Ȱ��ȭ ���� ���� �˻�
    public Text[] text_time; //�ð� ǥ���� text
    public Text btn_text; //���¿� ���� ��ư�� text �����ϱ� ���� text
    float time; //�ð�
    float cooking_time = 10.0f;
    float rest_time = 0.5f;
    void Start()
    {
        btn_active = false; //��ư �ʱ� ���� false�� �����
    }
    public void Btn_Click() //��ư Ŭ�� �̺�Ʈ
    {
        if (!btn_active)
        {
            SetTimerOn();
            btn_text.text = "Count..";
        }
        else
        {
            SetTimerOff();
            if (cooking_time- rest_time < time && time <cooking_time+ rest_time)
            {
                btn_text.text = "�ð� ��ġ �Ϸ�!";
            }
            else
            {
                btn_text.text = "�ð� ��ġ ����..";
            }
            //btn_text.text = "STOP!";
            time = 0;
        }
    }
    public void SetTimerOn() //��ư Ȱ��ȭ �޼ҵ�
    {
        btn_active = true;
    }
    public void SetTimerOff() //��ư ��Ȱ��ȭ �޼ҵ�
    {
        btn_active = false;
    }
    public void Update() //�ٲ�� �ð� text�� �ݿ��ϴ� update �����ֱ�
    {
        //�þ�� Ÿ�̸��� ���
        if (btn_active)
        {
            time += Time.deltaTime;
            text_time[0].text = ((int)time % 60).ToString() + "sec";
        }

        //�پ��� Ÿ�̸��� ���
        /*if (btn_active)
        {
            time -= Time.deltaTime;
            text_time[0].text = ((int)time / 3600).ToString();
            text_time[1].text = ((int)time / 60 % 60).ToString();
            text_time[2].text = ((int)time % 60).ToString();
        }*/
    }
}
