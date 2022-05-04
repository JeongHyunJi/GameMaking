using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class fishingButton : MonoBehaviour
{
    public static bool buttonControll = false; // true�� � ����
    public GameObject button;
    public Text buttonText;
    public static bool isSuccess = false;
    private Transform panel;
    public GameObject savePlayer;

    private void Start()
    {
        panel = GameObject.Find("ToggleCanvas").transform.Find("Panel");
    }
    public void stopButtonController()
    {
        GameObject ThisButton = EventSystem.current.currentSelectedGameObject; //��� ������ ������Ʈ(��ư)
        button = GameObject.FindGameObjectsWithTag("GameController")[Pond.currentLevel - 1]; //���ϴ� ������Ʈ
        if (ThisButton == button) // �̸��� ������ Ȯ��
            stopFloat();
    }

    public void stopFloat()
    {
        if (buttonControll)
        {
            GameFishing.floats[Pond.currentLevel-1].GetComponent<GameFishing>().Move(); 
            buttonControll = false;
        }
        else
        {
            GameFishing.floats[Pond.currentLevel-1].GetComponent<GameFishing>().Stop(); //�����ϴ� ��� -> 1�̸� �ð����. 0�̸� ����
            buttonControll = true;
            if (GameFishing.isInPond)
            {
                GameFishing.isInPond = false;
                if (Pond.currentLevel < 3)
                {
                    Pond.currentLevel++;
                    GameFishing.floats[Pond.currentLevel - 2].SetActive(false);
                    GameFishing.floats[Pond.currentLevel - 1].SetActive(true);
                    GameObject.FindWithTag("Pond").GetComponent<Pond>().Restart();
                }
                else
                {
                    isSuccess = true;
                    savePlayer.GetComponent<SavePlayer>().GetInvent(5 + GameLevel.level);
                    panel.GetComponent<GameOver>().Gameover();
                }
            }
            else
            {
                panel.GetComponent<GameOver>().Gameover();
            }
        }
        buttonText.text = buttonControll ? "start" : "stop";
    }
}
