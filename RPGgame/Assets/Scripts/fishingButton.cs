using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishingButton : MonoBehaviour
{
    public static bool button = false; // true�� � ����
    //public GameObject button;
    
    public void stopFloat()
    {
        if (button)
        {
            Time.timeScale = 1; //�����ϴ� ��� -> 1�̸� �ð����. 0�̸� ����
            button = false;
        }
        else
        {
            if (GameFishing.isInPond)
            {
                Debug.Log("���� ������ �Ѿ");
            }
            else
            {
                Debug.Log("��Ʈ �ϳ� ����");
            }
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
