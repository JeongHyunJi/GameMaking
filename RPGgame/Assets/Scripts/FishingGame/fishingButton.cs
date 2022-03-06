using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fishingButton : MonoBehaviour
{
    public bool buttonControll = false; // true�� � ����
    public GameObject button;
    
    public void stopFloat()
    {
        Rigidbody2D floatS = GameObject.Find("float"+Pond.currentLevel).GetComponent<GameFishing>().floatRigidbody;
        if (buttonControll)
        {
            floatS.velocity = new Vector2(0, 0); //�����ϴ� ��� -> 1�̸� �ð����. 0�̸� ����
            buttonControll = false;
        }
        else
        {
            if (GameFishing.isInPond)
            {
                Debug.Log("���� ������");
                GameObject.Find("FishingLevel").GetComponent<GameLevel>().NextLevel();
            }
            else
            {
                
            }
            //�����ϴ� ��� -> 1�̸� �ð����. 0�̸� ����
            GameObject.Find("float"+Pond.currentLevel).GetComponent<GameFishing>().Move();
            //Time.timeScale = 0;
            buttonControll = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
