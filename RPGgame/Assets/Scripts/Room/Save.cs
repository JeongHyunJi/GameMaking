using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Save : MonoBehaviour
{
    public GameObject suggest;
    public GameObject YesSave;
    Vector2 pos;

    void OffSaveAlarm()
    {
        YesSave.SetActive(false);
    }

    void Start()
    {
        suggest.SetActive(false);
        YesSave.SetActive(false);
        pos = this.gameObject.transform.position;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        print("�浹");

        if (other.tag == "bed")
        {
            
            suggest.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    public void BtnClick()
    {
        SavePlayer sp = FindObjectOfType<SavePlayer>();
        string BtnName = EventSystem.current.currentSelectedGameObject.name;

        if (BtnName == "Button_y") //����O
        {
            sp.SaveContent();
            print("����Ϸ�");
            suggest.SetActive(false);
            YesSave.SetActive(true);
            Invoke("OffSaveAlarm", 0.5f);
        }
        else if (BtnName == "Button_n") //����X
        {
            suggest.SetActive(false);
            print("������������");
        }
        Time.timeScale = 1;
        Vector2 changeXY = new Vector2(3.4f, -11.6f);
        this.gameObject.transform.position = changeXY;
        //Vector3(6.30131817,-8.10491562,0)
    }
}
