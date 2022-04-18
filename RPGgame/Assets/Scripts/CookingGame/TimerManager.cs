using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{

    //public GameObject FontEffect;

    //��ư
    static int BtnChk = 0;

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
    int two;
    int three;
    int four;
    int five;

    //�� �̵�
    private int count = 0;
    private int countY = 0;
    private int countN = 0;

    void Start()
    {
        btn_active = false; //��ư �ʱ� ���� false�� �����
        sr = go.GetComponent<SpriteRenderer>();
    }

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

    //��ư Ŭ�� �̺�Ʈ
    public void Btn_Click() 
    {

        if (BtnChk == 1)
        {
            SetTimerOff();
        }

        if (!btn_active && BtnChk==0)
        {
            SetTimerOn();
            btn_text.text = "Stop!";
            //FontEffect.GetComponent<FontEffect>().tartgetCall(btn_text.text);

            BtnChk = 1;
            two--;
            PlayerPrefs.SetInt("saved_2", two);
        }
        else
        {
            SetTimerOff();
            if (cooking_time- rest_time <= time && time <= cooking_time+ rest_time)
            {
                btn_text.text = "<color=#ffe650> Game Complete! </color>";
                //FontEffect.GetComponent<FontEffect>().tartgetCall(btn_text.text);
                InvokeRepeating("PrintFinalY", 2f, 3f);
            }
            else
            {
                btn_text.text = "<color=#68d168> Game Fail.. </color>";
                //FontEffect.GetComponent<FontEffect>().tartgetCall(btn_text.text);
                if (cooking_time - rest_time > time)
                {
                    InvokeRepeating("PrintFinalN_Not", 2f, 3f);
                }
                else
                {
                    InvokeRepeating("PrintFinalN_Burn", 2f, 3f);
                }
            }
            time = 0;
            InvokeRepeating("SceneChange", 4f, 3f);
        }
    }

    //������ ���� text
    public void PrintFinalY()
    {
        btn_text.text = "You can get a bread!";
        //FontEffect.GetComponent<FontEffect>().tartgetCall(btn_text.text);
        countY += 1;
        four++;
        PlayerPrefs.SetInt("saved_4", four);
        Debug.Log(four + ": ����");
    }
    //���н� ���� text
    public void PrintFinalN_Not()
    {
        btn_text.text = "You get a Not Baked Bread!";
        //FontEffect.GetComponent<FontEffect>().tartgetCall(btn_text.text);
        countN += 1;
        three++;
        PlayerPrefs.SetInt("saved_3", three);
        Debug.Log(four + ": ����");
    }
    public void PrintFinalN_Burn()
    {
        btn_text.text = "You get a Burned Bread!";
        //FontEffect.GetComponent<FontEffect>().tartgetCall(btn_text.text);
        countN += 1;
        five++;
        PlayerPrefs.SetInt("saved_5", five);
        Debug.Log(four + ": Ž");
    }

    public void Update() //�ٲ�� �ð� text�� �ݿ��ϴ� update �����ֱ�
    {
        two = PlayerPrefs.GetInt("saved_2");
        three = PlayerPrefs.GetInt("saved_3");
        four = PlayerPrefs.GetInt("saved_4");
        five = PlayerPrefs.GetInt("saved_5");

        if (btn_active)
        {
            time += Time.deltaTime;
            if (3.5f <= time && time <= 5.0f)
            {
                text_time[0].text = "Nice Baking!";
                sr.material.color = new Color(0.90f, 0.68f, 0.19f);
            }
            else if (time > 5.0f && time<7.5f)
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
                sr.material.color = new Color(1f, 1f,1f);
            }
        }
        if (count >= 1)
        {
            CancelInvoke("SceneChange");
        }
        if (countY >= 1)
        {
            CancelInvoke("PrintFinalY");
        }
        if (countN >= 1)
        {
            CancelInvoke("PrintFinalN");
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Home");
        count += 1;
        BtnChk = 0;
    }
}