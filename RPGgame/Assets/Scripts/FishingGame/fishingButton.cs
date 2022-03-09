using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class fishingButton : MonoBehaviour
{
    public bool buttonControll = false; // false�� � ����
    public GameObject button;
    
    public void stopButtonController()
    {
        GameObject ThisButton = EventSystem.current.currentSelectedGameObject;
        button = GameObject.FindGameObjectsWithTag("GameController")[Pond.currentLevel - 1];
        if (ThisButton == button)
            stopFloat();
    }

    public void stopFloat()
    {
        if (!buttonControll)
        {
            Time.timeScale = 1;
            buttonControll = false;
        }
        else
        {
            if (GameFishing.isInPond)
            {
                GameFishing.isInPond = false;
                if (Pond.currentLevel < 3)
                {
                    Pond.currentLevel++;
                    GameFishing.floats[Pond.currentLevel - 2].SetActive(false);
                    GameFishing.floats[Pond.currentLevel-1].SetActive(true);
                    GameObject.FindWithTag("Pond").GetComponent<Pond>().Restart();
                }
                else
                {
                    Debug.Log("success");
                }
            }
            else
            {
                Debug.Log("���� ������"); //�� ��ȯ
            }
            Time.timeScale = 0; //�����ϴ� ��� -> 1�̸� �ð����. 0�̸� ����
            buttonControll = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
