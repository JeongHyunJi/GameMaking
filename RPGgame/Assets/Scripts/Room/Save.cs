using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Save : MonoBehaviour
{
    public GameObject suggest;
    Vector2 pos;

    void Start()
    {
        suggest.SetActive(false);
        pos = this.gameObject.transform.position;
        print(pos);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
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
        }
        else if (BtnName == "Button_n") //����X
        {
            suggest.SetActive(false);
            print("������������");
        }
        Time.timeScale = 1;
        Vector2 changeXY = new Vector2(6.5f, -8.5f);
        this.gameObject.transform.position = changeXY;
        //Vector3(6.30131817,-8.10491562,0)
    }
}
