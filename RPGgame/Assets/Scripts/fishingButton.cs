using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishingButton : MonoBehaviour
{
    bool button = false; // true�� � ����
    //public GameObject button;

    public void stopFloat()
    {
        if (button)
        {
            Time.timeScale = 1; //�����ϴ� ��� -> 1�̸� ����. 0�̸� �ð����
            button = false;
        }
        else
        {
            Time.timeScale = 0;
            button = true;
        }
        //gameObject.GetComponent<GameFishing>()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
